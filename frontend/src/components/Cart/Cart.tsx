/**
 * @file Cart
 * @description Layout of the cart page
 * @Author Vikas Singh
 * @note
 * - cart btn displayed on nav bar
 * - edit quantity and remove from cart options
 */
import React from "react"
import { Button, useTheme } from "@mui/material"

import { useAppSelector } from "../../hooks/useAppSelector"
import CartItem from "./CartItem"
import ContainerProductCategory, {
  DisplayGrid,
} from "../../themes/categoryTheme"
import { useNavigate } from "react-router-dom"

/**
 * @description Cart outer structure, checks state from redux store and display's data is available
 * @returns JSX.Element
 */
const Cart = () => {
  const cartState = useAppSelector((state) => state.cart)
  const theme = useTheme()
  const navigate = useNavigate()

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
          C
        </span>
        art
      </h1>
      <aside
        style={{
          display: "flex",
          flexDirection: "row",
          marginBottom: "7rem",
        }}
      >
        <Button variant="outlined" onClick={() => navigate("/placeorder")}>
          Place Order
        </Button>
      </aside>
      <DisplayGrid gap={2} gridTemplateColumns={"repeat(1,1fr)"}>
        {cartState.length ? (
          cartState.map((item, key) => <CartItem item={item} key={item.id} />)
        ) : (
          <div> No Item added to Cart</div>
        )}
      </DisplayGrid>
    </ContainerProductCategory>
  )
}

export default Cart
