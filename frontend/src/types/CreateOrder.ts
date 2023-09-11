export interface CreateOrderType {
  userId: string
  addressId: string
  orderProducts: { productId: string; quantity: number }[]
}
