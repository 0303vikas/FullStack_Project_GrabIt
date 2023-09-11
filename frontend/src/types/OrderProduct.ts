import { ProductType } from "./Product"

export interface OrderProductType {
  quantity: number
  orderId: string
  product: ProductType
}
