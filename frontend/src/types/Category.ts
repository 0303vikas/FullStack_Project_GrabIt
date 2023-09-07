import { NewCategoryType } from "./NewCategory"

export interface CategoryType {
  id: string
  name: string
  imageURL: string
}

export interface UpdateCategoryType {
  id: string
  update: NewCategoryType
}
