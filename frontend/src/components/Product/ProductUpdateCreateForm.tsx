import React, { useState } from "react"
import { Delete } from "@mui/icons-material"
import {
  Button,
  CardMedia,
  IconButton,
  MenuItem,
  TextField,
  useTheme,
} from "@mui/material"

import { NewProductType } from "../../types/NewProduct"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import { useNavigate } from "react-router-dom"
import { useAppSelector } from "../../hooks/useAppSelector"
import {
  clearProductError,
  createProduct,
  deleteProduct,
  updateProduct,
} from "../../redux/reducers/productReducer"
import { AxiosError } from "axios"
import { ProductType } from "../../types/Product"
import {
  DisplayCardHorizontal,
  HorizontalCardBox,
} from "../../themes/horizontalCardTheme"
import { current } from "@reduxjs/toolkit"

export const ProductUpdateCreateForm = ({
  formType,
  updateData,
}: {
  formType: string
  updateData?: ProductType
}) => {
  const [title, setTitle] = useState(updateData?.title || "")
  const [description, setDescription] = useState(updateData?.description || "")
  const [stock, setStock] = useState(10)
  const [currentCategory, setCurrentCategory] = useState(
    updateData?.category.name || ""
  )
  const [price, setPrice] = useState(updateData?.price || 0)
  const [images, setImages] = useState<string[]>(updateData?.imageURLList || [])
  const [image, setImage] = useState<string>("")
  const [currentImage, setCurrentImage] = useState(
    updateData?.imageURLList[0] || ""
  )
  const dispatch = useAppDispatch()
  const navigate = useNavigate()
  const theme = useTheme()
  const { category } = useAppSelector((store) => store.categories)

  const formSubmitHandler = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()

    const findCategory = category.find((item) => item.name === currentCategory)

    if (findCategory === undefined) {
      alert(
        "Category name wasn't found created. Choose a correct category name"
      )
      return false
    }

    if (
      title === "" ||
      description === "" ||
      stock === 0 ||
      price === 0 ||
      images.length === 0 ||
      currentCategory === ""
    ) {
      alert("Please fill all the fields.")
      return false
    }

    const newProduct: NewProductType = {
      title: title || "Without Title",
      price: price || 10,
      stock: stock || 10,
      description: description || "Description to be created",
      categoryId: findCategory.id,
      imageURLList: images,
    }

    if (formType === "Update" && updateData) {
      dispatch(updateProduct({ id: updateData.id, update: newProduct })).then(
        (data) => {
          if (data.type === "updateProduct/fulfilled") {
            if (data.payload instanceof AxiosError) {
              setTimeout(() => {
                dispatch(clearProductError())
              }, 3000)
              return false
            } else {
              alert("Product Updated.")
              navigate("/")
              return true
            }
          } else {
            alert("Error updating product.")
          }
        }
      )
    } else {
      dispatch(createProduct(newProduct)).then((data) => {
        if (data.type === "createProduct/fulfilled") {
          if (data.payload instanceof AxiosError) {
            setTimeout(() => {
              dispatch(clearProductError())
            }, 3000)
            return false
          } else {
            alert("Product created")
            navigate("/")
            return true
          }
        } else {
          alert("Error creating product.")
        }
      })
    }
  }

  const handleProductDelete = () => {
    alert("Delete Product?")
    if (updateData === undefined) return false
    dispatch(deleteProduct(updateData.id))
    setTimeout(() => {
      navigate("/")
    }, 2000)
  }

  const handleImageRemov = (item: string) => {
    setImages([...images.filter((url) => url !== item)])
  }

  const addImageToList = (arg: string) => {
    if (arg === "") {
      alert("Please enter a valid image url.")
      return false
    }
    setImages([...images, arg])
    setImage("")
    alert("Image added Successfully.")
  }

  return (
    <DisplayCardHorizontal>
      <aside id="image-handling" style={{ width: "50%", height: "100%" }}>
        <CardMedia
          component="img"
          height="400"
          image={
            currentImage === undefined ||
            currentImage === "" ||
            currentImage === null ||
            images === null ||
            images === undefined
              ? "https://slp-statics.astockcdn.net/static_assets/staging/23summer/home/EMEA/curated-collections/card-5.jpg?width=580&format=webp"
              : currentImage
          }
          alt={title + " image."}
          sx={{
            [theme.breakpoints.down("md")]: {
              display: "none",
            },
            height: "100%",
          }}
        />
      </aside>
      <HorizontalCardBox>
        <form
          onSubmit={formSubmitHandler}
          style={{ display: "grid", rowGap: "2rem" }}
          id="create-Form"
        >
          <TextField
            id="create-Form--Text"
            label="Title"
            value={title}
            variant="filled"
            onChange={(e) => setTitle(e.target.value)}
          />
          <TextField
            id="create-Form--Price"
            label="Price"
            value={price}
            type="number"
            variant="filled"
            InputProps={{
              inputProps: {
                min: 1,
              },
            }}
            onChange={(e) => setPrice(Number(e.target.value))}
          />
          <TextField
            id="create-Form--Stock"
            label="Stock"
            value={stock}
            type="number"
            variant="filled"
            InputProps={{ inputProps: { min: 10 } }}
            onChange={(e) => setStock(Number(e.target.value))}
          />
          <TextField
            id="create-Form--Description"
            label="Description"
            value={description}
            variant="filled"
            onChange={(e) => setDescription(e.target.value)}
          />
          {category.length && (
            <TextField
              id="create-Form--Category"
              select
              label="Categories"
              defaultValue=""
              value={currentCategory ? currentCategory : ""}
              onChange={(e) => setCurrentCategory(e.target.value)}
            >
              {category.map((item) => (
                <MenuItem value={item.name} key={item.id}>
                  {item.name}
                </MenuItem>
              ))}
            </TextField>
          )}
          <div id="create-Form--AddImage">
            <TextField
              id="create-Form--Image"
              label="Image"
              variant="filled"
              value={image}
              onChange={(e) => {
                setImage(e.target.value)
              }}
            />
            <Button
              variant="contained"
              color="secondary"
              onClick={() => addImageToList(image)}
            >
              AddImage
            </Button>
          </div>

          {images && (
            <TextField
              id="create-Form--Category"
              select
              label="Images"
              value={
                currentImage === undefined ||
                currentImage === null ||
                images === null ||
                images === undefined
                  ? ""
                  : currentImage
              }
              onChange={(e) => setCurrentImage(e.target.value)}
            >
              {images.map((item) => (
                <MenuItem value={item} key={item}>
                  {item}

                  <IconButton onClick={() => handleImageRemov(item)}>
                    <Delete color="error" />
                  </IconButton>
                </MenuItem>
              ))}
            </TextField>
          )}

          <Button variant="contained" color="primary" type="submit">
            {formType}
          </Button>
          {formType === "Update" && (
            <Button
              variant="contained"
              color="error"
              onClick={handleProductDelete}
            >
              Delete
            </Button>
          )}
        </form>
      </HorizontalCardBox>
    </DisplayCardHorizontal>
  )
}
