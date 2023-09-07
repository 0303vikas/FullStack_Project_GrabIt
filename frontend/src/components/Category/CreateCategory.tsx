import { useEffect } from "react"

import { DisplayGrid } from "../../themes/categoryTheme"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import { fetchCategoryData } from "../../redux/reducers/categoryReducer"
import { CategoryUpdateCreateForm } from "./CategoryUpdateCreateForm"

const CreateCategory = () => {
  const dispatch = useAppDispatch()

  useEffect(() => {
    dispatch(fetchCategoryData())
  }, [])

  return (
    <DisplayGrid gap={2} gridTemplateColumns={"repeat(1,1fr)"}>
      <CategoryUpdateCreateForm formType="Create" />
    </DisplayGrid>
  )
}

export default CreateCategory
