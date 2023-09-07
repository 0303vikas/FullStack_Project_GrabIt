/**
 * @file CreateProduct
 * @description Component for creating new product
 * @Author Vikas Singh
 * @notes
 *  - photo button not created yet
 */
import { useEffect, useState } from "react"

import { DisplayGrid } from "../../themes/categoryTheme"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import { fetchCategoryData } from "../../redux/reducers/categoryReducer"
import { ProductUpdateCreateForm } from "./ProductUpdateCreateForm"

/**
 * @description Create Product page. After the product is created user is redirecd to login page
 * @returns JSX.Element
 */
export const CreateProduct = () => {
  const dispatch = useAppDispatch()

  useEffect(() => {
    dispatch(fetchCategoryData())
  }, [])

  return (
    <DisplayGrid gap={2} gridTemplateColumns={"repeat(1,1fr)"}>
      <ProductUpdateCreateForm formType="Create" />
    </DisplayGrid>
  )
}
