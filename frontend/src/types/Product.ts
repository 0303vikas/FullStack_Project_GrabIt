import { CategoryType } from "./Category"

export interface ProductType {
  id: string
  title: string
  price: number
  description: string
  category: CategoryType
  imageURLList: string[]
  creationAt?: string
  updatedAt?: string
}
