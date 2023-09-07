/**
 * @file Category
 * @description Comonents that return the category type component
 * @Author Vikas Singh
 * @note
 * - Each card element inside category, points to products from that category
 * - fetching all category from url is handled in home page
 * - error handling in the home page
 */

import React, { useEffect, useState } from "react"
import {
  CardActionArea,
  CardContent,
  CardMedia,
  Pagination,
  Typography,
  useTheme,
  Box,
  CircularProgress,
  CardActions,
  IconButton,
} from "@mui/material"
import { useNavigate } from "react-router-dom"

import { useAppDispatch } from "../../hooks/useAppDispatch"
import { useAppSelector } from "../../hooks/useAppSelector"
import ContainerProductCategory, {
  DisplayGrid,
  DisplayCard,
} from "../../themes/categoryTheme"
import { CategoryType } from "../../types/Category"
import { fetchCategoryData } from "../../redux/reducers/categoryReducer"
import { Settings } from "@mui/icons-material"
import { CreateDialogBox } from "../Common/CreateDialogBox"

/**
 * @description check redux store cart state and renders the element accordingly
 * if ( loading ) from redux store
 * @returns loading...
 * else
 * @returns Category componenent
 * @notes
 * - category data is not store in react state, and due to api fetching time,
 * - category data change in the store doesn't rerenders the page, so
 * - for initial render we store the first 8 categories in the useState
 */
const Category = () => {
  const dispatch = useAppDispatch()
  const theme = useTheme()
  const [currentPage, setCurrentPage] = useState<number>(1)
  const navigate = useNavigate()
  const reduxState = useAppSelector((state) => state)
  const { category, error, loading } = reduxState.categories
  const { currentUser } = reduxState.user
  const [slicedArray, setSlicedArray] = useState<CategoryType[]>(
    category.slice(0, 8)
  ) // for component rerender after category state change

  useEffect(() => {
    dispatch(fetchCategoryData())
  }, [])

  const handlePageChange = (
    event: React.ChangeEvent<unknown>,
    value: number
  ) => {
    setCurrentPage(value)
    setSlicedArray(category.slice((value - 1) * 8, value * 8))
  }

  if (loading)
    return (
      <Box sx={{ marginLeft: "50%" }}>
        <h1 style={{ color: theme.palette.info.main }}>Loading</h1>
        <CircularProgress style={{ color: theme.palette.info.main }} />
      </Box>
    )

  return (
    <ContainerProductCategory
      id="category--container"
      className="productCategory--container"
    >
      <h1
        id="page-heading"
        style={{
          ...theme.typography.h2,
          textTransform: "uppercase",
          fontSize: "4rem",
        }}
      >
        <span id="page-heading--firstLetter" style={{ fontSize: "100px" }}>
          C
        </span>
        ategories
      </h1>
      <CreateDialogBox />

      <DisplayGrid gap={1} gridTemplateColumns={"repeat(4,1fr)"}>
        {/**
         * if category exists
         * use category array
         * else
         * use slicedArray
         */}

        {(category.length ? category : slicedArray)
          .slice(currentPage * 8 - 8, currentPage * 8)
          .map((item, index) => {
            return (
              <DisplayCard key={item.id}>
                <CardActionArea
                  onClick={() => navigate(`/category/${item.id}/products`)}
                >
                  <CardMedia
                    component="img"
                    height="140"
                    image={item.imageURL}
                    alt={item.name + " image."}
                  />
                  <CardContent>
                    <Typography>{item.name}</Typography>
                  </CardContent>
                </CardActionArea>
                <CardActions sx={{ bottom: "0px", minHeight: "30%" }}>
                  {/**
                   * if current user exists and role is admin, then
                   * display setting btn
                   * else return display non
                   */}
                  {currentUser ? (
                    currentUser.role === 0 ? (
                      <IconButton
                        aria-label="Edit Category"
                        onClick={() => navigate(`/category/edit/${item.id}`)}
                      >
                        <Settings
                          color="info"
                          titleAccess="Go to Category setting"
                        />
                      </IconButton>
                    ) : null
                  ) : null}
                </CardActions>
              </DisplayCard>
            )
          })}
      </DisplayGrid>
      <Pagination
        count={Math.ceil(category.length / 8)}
        page={currentPage}
        onChange={handlePageChange}
        variant="outlined"
        color="primary"
        sx={{ padding: "3rem 0rem" }}
      />
    </ContainerProductCategory>
  )
}

export default Category
