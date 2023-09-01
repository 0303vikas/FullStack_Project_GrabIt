import { ProductType } from "./Product"

export interface UpdateProductType {
  id: string
  update: Partial<ProductType>
}
