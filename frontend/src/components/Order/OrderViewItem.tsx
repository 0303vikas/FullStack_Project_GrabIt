import { Box, Button, CardMedia, useTheme } from "@mui/material"
import * as React from "react"
import { styled } from "@mui/material/styles"
import Table from "@mui/material/Table"
import TableBody from "@mui/material/TableBody"
import TableCell, { tableCellClasses } from "@mui/material/TableCell"
import TableContainer from "@mui/material/TableContainer"
import TableHead from "@mui/material/TableHead"
import TableRow from "@mui/material/TableRow"
import Paper from "@mui/material/Paper"

import { DisplayCardHorizontal } from "../../themes/horizontalCardTheme"
import { OrderProductType } from "../../types/OrderProduct"
import { OrderType } from "../../types/Order"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import { OrderStatus } from "../../types/EnumOrderStatus"
import {
  cancelOrder,
  clearOrderError,
  updateOrderStatus,
} from "../../redux/reducers/orderReducer"
import { AxiosError } from "axios"
import { useAppSelector } from "../../hooks/useAppSelector"

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}))

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}))

export const OrderViewItem = ({ order }: { order: OrderType }) => {
  const dispatch = useAppDispatch()
  const { currentUser } = useAppSelector((state) => state.user)

  const handleOrderCancel = () => {
    alert("Profile Delete Confirm?")
    dispatch(cancelOrder(order.id)).then((res) => {
      if (res.type === "createOrder/fulfilled") {
        if (res.payload instanceof AxiosError) {
          setTimeout(() => {
            dispatch(clearOrderError())
          }, 3000)
          return false
        } else {
          alert("Order Canceled Successfully.")
        }
      }
    })
  }

  const handleOrderStatusChange = (status: number) => {
    alert("Order Status Confirm?")
    const data = {
      id: order.id,
      status: status,
    }
    dispatch(updateOrderStatus(data)).then((res) => {
      if (res.type === "updateOrderStatus/fulfilled") {
        if (res.payload instanceof AxiosError) {
          setTimeout(() => {
            dispatch(clearOrderError())
          }, 3000)
          return false
        } else {
          alert("Order status Updated Successfully.")
        }
      }
    })
  }

  return (
    <DisplayCardHorizontal sx={{ flexDirection: "column" }}>
      <div
        style={{
          display: "flex",
          flexDirection: "row",
          justifyContent: "space-between",
          padding: "1rem 2rem",
        }}
      >
        <address>
          <h3>Address</h3>
          Street: {order.address.street} <br /> City: {order.address.city}{" "}
          <br /> State: {order.address.state} <br />
          Postal Code: {order.address.postalCode} <br /> Country:{" "}
          {order.address.country}
        </address>
        <aside>
          <h3>Status</h3>
          <span
            style={{
              fontWeight: "bold",
              color: "blue",
              border: "solid 1px black",
              padding: "0.5rem 1rem",
            }}
          >
            {OrderStatus[Number(order.status)]}
          </span>
        </aside>
      </div>

      <TableContainer component={Paper} sx={{ borderTop: "1px solid" }}>
        <Table sx={{ minWidth: 700 }} aria-label="customized table">
          <TableHead>
            <TableRow>
              <StyledTableCell>Title</StyledTableCell>
              <StyledTableCell align="right">Quantity</StyledTableCell>
              <StyledTableCell align="right">Price</StyledTableCell>
              <StyledTableCell align="right">Total Price</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {order.orderProducts.map((row) => (
              <StyledTableRow key={row.product.id}>
                <StyledTableCell component="th" scope="row">
                  {row.product.title}
                </StyledTableCell>
                <StyledTableCell align="right">{row.quantity}</StyledTableCell>
                <StyledTableCell align="right">
                  {row.product.price}
                </StyledTableCell>
                <StyledTableCell align="right">
                  {row.quantity * row.product.price}
                </StyledTableCell>
              </StyledTableRow>
            ))}
            <TableRow>
              <StyledTableCell component="th" scope="row">
                Total: {order.totalPrice}
              </StyledTableCell>
              {order.status !== "0" && (
                <StyledTableCell>
                  <Button
                    variant="contained"
                    color="error"
                    onClick={handleOrderCancel}
                  >
                    Cancel Order
                  </Button>
                </StyledTableCell>
              )}
              {currentUser?.role === 0 && (
                <StyledTableCell>
                  <Button
                    variant="outlined"
                    color="primary"
                    onClick={() => handleOrderStatusChange(0)}
                  >
                    Deliveried
                  </Button>
                  <Button
                    variant="outlined"
                    color="primary"
                    onClick={() => handleOrderStatusChange(1)}
                  >
                    Shipped
                  </Button>
                  <Button
                    variant="outlined"
                    color="primary"
                    onClick={() => handleOrderStatusChange(2)}
                  >
                    InProcess
                  </Button>

                  <Button
                    variant="outlined"
                    color="primary"
                    onClick={() => handleOrderStatusChange(3)}
                  >
                    Waiting
                  </Button>
                </StyledTableCell>
              )}
            </TableRow>
          </TableBody>
        </Table>
      </TableContainer>
    </DisplayCardHorizontal>
  )
}
