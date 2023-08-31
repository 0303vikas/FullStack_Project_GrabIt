export interface CategoryType {
  id: string
  name: string
  imageURL: string
}

export interface UpdateCategoryType {
  id: string
  newData: Partial<CategoryType>
}
