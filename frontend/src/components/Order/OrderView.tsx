import { useEffect } from "react"

import { useAppSelector } from "../../hooks/useAppSelector"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import {
  fetchAllOrders,
  fetchAllUserOrders,
} from "../../redux/reducers/orderReducer"
import { ErrorComponent } from "../Common/ErrorComponent"
import ContainerProductCategory, {
  DisplayGrid,
} from "../../themes/categoryTheme"
import { useTheme } from "@mui/material"
import { OrderViewItem } from "./OrderViewItem"

export const OrderView = () => {
  const theme = useTheme()
  const reduxStore = useAppSelector((store) => store)

  const currentUser = reduxStore.user.currentUser
  const { orders, loading, error } = reduxStore.order
  const dispatch = useAppDispatch()

  useEffect(() => {
    if (currentUser) {
      if (currentUser.role === 0) {
        dispatch(fetchAllOrders())
      } else {
        dispatch(fetchAllUserOrders(currentUser.id))
      }
    }
  }, [currentUser])

  if (loading) return <div>Loading...</div>
  if (error.message !== "")
    return (
      <ErrorComponent message={error.message} statusCode={error.statusCode} />
    )

  return (
    <ContainerProductCategory
      id="product--container"
      className="productCategory--container"
    >
      <h1
        id="page-heading"
        style={{
          ...theme.typography.h2,
          textTransform: "uppercase",
          fontSize: "4rem",
        }}
      >
        <span id="page-heading--firstLetter" style={{ fontSize: "100px" }}>
          O
        </span>
        rders
      </h1>
      <DisplayGrid gap={2} gridTemplateColumns={"repeat(1,1fr)"}>
        {orders.length ? (
          orders.map((item, key) => (
            <OrderViewItem order={item} key={item.id} />
          ))
        ) : (
          <div> No Orders were found.</div>
        )}
      </DisplayGrid>
    </ContainerProductCategory>
  )
}
