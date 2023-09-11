import React from "react"
import { Button, useTheme } from "@mui/material"

import ContainerProductCategory, {
  DisplayGrid,
} from "../../themes/categoryTheme"
import {
  OrderMainContainer,
  OrderMainItem,
} from "../../themes/createOrderTheme"
import { OrderAddressForm } from "./OrderAddressForm"
import { OrderProductForm } from "./OrderProductForm"
import { useEffect, useState } from "react"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import { clearOrderError, createOrder } from "../../redux/reducers/orderReducer"
import { useAppSelector } from "../../hooks/useAppSelector"
import { AddressType } from "../../types/Address"
import { CartType } from "../../types/CartType"
import { useNavigate } from "react-router-dom"
import { clearUserError } from "../../redux/reducers/userReducer"
import { AxiosError } from "axios"
import { fetchAllUserAddress } from "../../redux/reducers/addressReducer"

export const CreateOrder = () => {
  const theme = useTheme()
  const [orderProductData, setOrderProductData] = useState<CartType[]>([])
  const [deliveryAddress, setDeliveryAddress] = useState<AddressType>({
    id: "",
    street: "",
    city: "",
    state: "",
    postalCode: "",
    country: "",
  })
  const navigate = useNavigate()
  const dispatch = useAppDispatch()
  const stateReduxStore = useAppSelector((state) => state)
  const { currentUser } = stateReduxStore.user
  const { error } = stateReduxStore.order

  useEffect(() => {
    if (currentUser) {
      dispatch(fetchAllUserAddress(currentUser.id))
    }
  }, [currentUser])

  const handleOrderSubmit = () => {
    if (currentUser === undefined) return alert("Please login to continue")

    if (orderProductData.length === 0)
      return alert("Please add products to cart")

    if (deliveryAddress.id === "") return alert("Please add delivery address")

    var orderProducts: { productId: string; quantity: number }[] = []
    orderProductData.forEach((item) => {
      orderProducts.push({
        productId: item.id,
        quantity: item.quantity,
      })
    })

    var orderData = {
      userId: currentUser.id,
      addressId: deliveryAddress.id,
      orderProducts: orderProducts,
    }

    dispatch(createOrder(orderData)).then((data) => {
      if (data.type === "createOrder/fulfilled") {
        if (data.payload instanceof AxiosError) {
          setTimeout(() => {
            dispatch(clearOrderError())
          }, 3000)
          return false
        } else {
          alert("Creating order unsuccessfull.")
          navigate("/")
        }
      }
    })
  }

  return (
    <ContainerProductCategory
      id="create--container"
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
        rder
      </h1>

      <DisplayGrid sx={{ flexGrow: 1 }}>
        {error && <div>{error.message}</div>}
        <OrderMainContainer container spacing={{ xs: 1 }} direction={"column"}>
          <OrderProductForm setOrderProductData={setOrderProductData} />
          <hr />
          <OrderAddressForm setDeliveryAddress={setDeliveryAddress} />
          <hr />
          <OrderMainItem item>
            <Button sx={{ width: "100%" }} onClick={handleOrderSubmit}>
              3. Confirm Order
            </Button>
          </OrderMainItem>
        </OrderMainContainer>
      </DisplayGrid>
    </ContainerProductCategory>
  )
}
