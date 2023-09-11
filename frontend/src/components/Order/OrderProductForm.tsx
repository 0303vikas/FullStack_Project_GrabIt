import { Button, TextField } from "@mui/material"
import { OrderMainItem } from "../../themes/createOrderTheme"
import { useState } from "react"
import { DisplayGrid } from "../../themes/categoryTheme"
import { useAppSelector } from "../../hooks/useAppSelector"
import CartItem from "../Cart/CartItem"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import { Done } from "@mui/icons-material"
import { CartType } from "../../types/CartType"

export const OrderProductForm = ({
  setOrderProductData,
}: {
  setOrderProductData: React.Dispatch<React.SetStateAction<CartType[]>>
}) => {
  const [divDisplay, setDivDisplay] = useState(false)
  const [orderProductConfirmed, setOrderProductConfirmed] = useState(false)
  const stateRedux = useAppSelector((state) => state)
  const cartState = stateRedux.cart

  return (
    <OrderMainItem item>
      <Button sx={{ width: "100%" }} onClick={() => setDivDisplay(!divDisplay)}>
        1. Confirm Order Products{" "}
        {orderProductConfirmed && <Done sx={{ color: "green" }} />}
      </Button>

      {divDisplay && (
        <div>
          {cartState.length ? (
            cartState.map((item, key) => <CartItem item={item} key={item.id} />)
          ) : (
            <div> No Item added to Cart</div>
          )}
          <Button
            onClick={() => {
              setOrderProductData(cartState)
              setDivDisplay(!divDisplay)
              setOrderProductConfirmed(true)
            }}
            color="primary"
            variant="contained"
            sx={{ width: "100%" }}
          >
            Confirm Order Products
          </Button>
        </div>
      )}
    </OrderMainItem>
  )
}
