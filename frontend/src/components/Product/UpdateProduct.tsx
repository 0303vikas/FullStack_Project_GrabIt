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
import { Delete } from "@mui/icons-material"

import ContainerProductCategory, {
  DisplayGrid,
} from "../../themes/categoryTheme"
import { useAppSelector } from "../../hooks/useAppSelector"
import {
  deleteProduct,
  fetchProductData,
} from "../../redux/reducers/productReducer"
import { fetchCategoryData } from "../../redux/reducers/categoryReducer"
import { ProductUpdateCreateForm } from "./ProductUpdateCreateForm"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import { ProductType } from "../../types/Product"

export const UpdateProduct = () => {
  const theme = useTheme()
  const { id } = useParams()
  const { products, loading, error } = useAppSelector((store) => store.product)
  const dispatch = useAppDispatch()

  useEffect(() => {
    dispatch(fetchProductData())
  }, [])

  const findProduct = products.find((item) => item.id === id)
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
      {findProduct && (
        <UpdateCard product={findProduct} loading={loading} error={error} />
      )}
    </ContainerProductCategory>
  )
}

const UpdateCard = ({
  product,
  loading,
  error,
}: {
  product: ProductType
  loading: boolean
  error: string
}) => {
  const dispatch = useAppDispatch()
  const theme = useTheme()

  useEffect(() => {
    dispatch(fetchCategoryData())
  }, [])

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
      <ProductUpdateCreateForm formType="Update" updateData={product} />
    </DisplayGrid>
  )
}
