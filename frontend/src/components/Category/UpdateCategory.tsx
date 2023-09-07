/**
 * @file DisplayData
 * @description DisplayArea for all the breweries on the home page + pagination handling function
 * @Author Vikas Singh
 * @note
 * - Adding image option not added yet
 */
import { useEffect } from "react"
import { useTheme, Box, CircularProgress } from "@mui/material"
import { useParams } from "react-router-dom"

import ContainerProductCategory, {
  DisplayGrid,
} from "../../themes/categoryTheme"
import { useAppSelector } from "../../hooks/useAppSelector"
import { fetchCategoryData } from "../../redux/reducers/categoryReducer"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import { CategoryType } from "../../types/Category"
import { CategoryUpdateCreateForm } from "./CategoryUpdateCreateForm"

export const UpdateCategory = () => {
  const theme = useTheme()
  const { id } = useParams()
  const { loading, error, category } = useAppSelector(
    (store) => store.categories
  )
  const dispatch = useAppDispatch()

  useEffect(() => {
    dispatch(fetchCategoryData())
  }, [])

  const findCategory = category.find((item) => item.id === id)
  return (
    <ContainerProductCategory
      id="product--container"
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
          U
        </span>
        pdate
      </h1>
      {findCategory && (
        <UpdateCard category={findCategory} loading={loading} error={error} />
      )}
    </ContainerProductCategory>
  )
}

const UpdateCard = ({
  category,
  loading,
  error,
}: {
  category: CategoryType
  loading: boolean
  error: string
}) => {
  const theme = useTheme()

  if (loading)
    return (
      <Box sx={{ marginLeft: "50%" }}>
        <h1 style={{ color: theme.palette.info.main }}>Loading</h1>
        <CircularProgress style={{ color: theme.palette.info.main }} />
      </Box>
    )

  if (error) return <div>{error}</div>

  return (
    <DisplayGrid gap={2} gridTemplateColumns={"repeat(1,1fr)"}>
      <CategoryUpdateCreateForm formType="Update" currentCategory={category} />
    </DisplayGrid>
  )
}
