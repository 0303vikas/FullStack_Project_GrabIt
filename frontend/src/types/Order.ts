import { Address } from "cluster"
import { OrderProductType } from "./OrderProduct"
import { PaymentType } from "./Payment"

export interface OrderType {
  id: string
  totalPrice: number
  status: string
  address: Address
  orderProducts: OrderProductType[]
  payment: PaymentType
}
