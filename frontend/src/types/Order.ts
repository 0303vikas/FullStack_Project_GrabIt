import { AddressType } from "./Address"
import { OrderProductType } from "./OrderProduct"

export interface OrderType {
  id: string
  totalPrice: number
  status: string
  address: AddressType
  orderProducts: OrderProductType[]
}
