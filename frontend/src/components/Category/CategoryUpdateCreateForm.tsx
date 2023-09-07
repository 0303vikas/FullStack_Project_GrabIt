import { useState } from "react"
import { Button, CardMedia, TextField, useTheme } from "@mui/material"
import { useNavigate } from "react-router-dom"
import { AxiosError } from "axios"

import {
  DisplayCardHorizontal,
  HorizontalCardBox,
} from "../../themes/horizontalCardTheme"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import {
  clearCategoryError,
  createCategory,
  deleteCategory,
  updateCategory,
} from "../../redux/reducers/categoryReducer"
import { NewCategoryType } from "../../types/NewCategory"
import { CategoryType } from "../../types/Category"
import { useAppSelector } from "../../hooks/useAppSelector"

export const CategoryUpdateCreateForm = ({
  formType,
  currentCategory,
}: {
  formType: string
  currentCategory?: CategoryType
}) => {
  const theme = useTheme()
  const [image, setImage] = useState(
    currentCategory?.imageURL ||
      "https://slp-statics.astockcdn.net/static_assets/staging/23summer/home/EMEA/curated-collections/card-1.jpg?width=580&format=webp"
  )
  const [name, setName] = useState(currentCategory?.name || "")
  const navigate = useNavigate()
  const dispatch = useAppDispatch()
  const { category } = useAppSelector((store) => store.categories)

  const formHandler = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    if (name === "" || image === "") {
      alert("Name and image are required.")
      return false
    }

    const newCategory: NewCategoryType = {
      name: name,
      imageURL: image,
    }

    if (formType === "Create") {
      if (category.find((item) => item.name === name)) {
        alert("Category with the name already exists.")
        return false
      }

      dispatch(createCategory(newCategory)).then((data) => {
        if (data.type === "createCategory/fulfilled") {
          if (data.payload instanceof AxiosError) {
            setTimeout(() => {
              dispatch(clearCategoryError())
            }, 3000)
            return false
          } else {
            console.log("Create Category is working")
            alert("Category Created Successfully.")
            navigate("/")
            return true
          }
        }
      })
    } else if (formType === "Update" && currentCategory) {
      dispatch(
        updateCategory({ id: currentCategory.id, update: newCategory })
      ).then((data) => {
        if (data.type === "updateCategory/fulfilled") {
          if (data.payload instanceof AxiosError) {
            setTimeout(() => {
              dispatch(clearCategoryError())
            }, 3000)
            return false
          } else {
            alert("Category UPdated Successfully.")
            navigate("/")
          }
        }
      })
    }
  }

  const handleCategoryDelete = () => {
    alert("Delete Category?")
    if (currentCategory === undefined) return false
    dispatch(deleteCategory(currentCategory.id))
    setTimeout(() => {
      navigate("/")
    }, 2000)
  }

  return (
    <DisplayCardHorizontal>
      <aside id="image-handling">
        <CardMedia
          component="img"
          height="400"
          image={image ? image : ""}
          alt={name ? name + " image." : "Category Image."}
          sx={{
            [theme.breakpoints.down("md")]: {
              display: "none",
            },
          }}
        />
      </aside>

      <HorizontalCardBox>
        <form
          style={{ display: "grid", rowGap: "2rem" }}
          onSubmit={formHandler}
          id="create-Form"
        >
          <TextField
            id="create-Form--Text"
            label="Title"
            value={name}
            variant="filled"
            onChange={(e) => setName(e.target.value)}
          />
          <TextField
            id="create-Form--Image"
            label="Images"
            value={image ? image : ""}
            onChange={(e) => setImage(e.target.value)}
          />
          <Button variant="contained" color="primary" type="submit">
            {formType}
          </Button>
          {formType === "Update" && (
            <Button
              variant="contained"
              color="error"
              onClick={handleCategoryDelete}
            >
              Delete
            </Button>
          )}
        </form>
      </HorizontalCardBox>
    </DisplayCardHorizontal>
  )
}
