import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import { ErrorMessageType } from "../../types/ErrorType"
import { OrderType } from "../../types/Order"
import { CreateOrderType } from "../../types/CreateOrder"
import axios, { AxiosError } from "axios"

const initialState: {
  orders: OrderType[]
  loading: boolean
  error: ErrorMessageType
} = {
  orders: [],
  loading: false,
  error: {
    message: "",
    statusCode: 200,
  },
}

export const fetchAllOrders = createAsyncThunk("getAllOrders", async () => {
  try {
    const request = await axios.get<OrderType[]>(
      `${process.env.REACT_APP_URL}/api/v1/orders`,
      {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("userToken")}`,
        },
      }
    )
    return request.data
  } catch (e) {
    const error = e as AxiosError
    return error
  }
})

export const fetchAllUserOrders = createAsyncThunk(
  "getAllUserOrders",
  async (id: string) => {
    try {
      const request = await axios.get<OrderType[]>(
        `${process.env.REACT_APP_URL}/api/v1/orders/getordersbyuserid/${id}`,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("userToken")}`,
          },
        }
      )
      return request.data
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

export const createOrder = createAsyncThunk(
  "createOrder",
  async (order: CreateOrderType) => {
    try {
      const request = await axios.post<OrderType>(
        `${process.env.REACT_APP_URL}/api/v1/orders`,
        order,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("userToken")}`,
          },
        }
      )
      return request.data
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

export const updateOrderStatus = createAsyncThunk(
  "updateOrderStatus",
  async ({ id, status }: { id: string; status: number }) => {
    try {
      const request = await axios.put<OrderType>(
        `${process.env.REACT_APP_URL}/api/v1/orders/updateorderstatus/${id}`,
        status,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("userToken")}`,
            "Content-Type": "application/json",
          },
        }
      )
      return { status: status, id: id }
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

export const cancelOrder = createAsyncThunk(
  "cancelOrder",
  async (id: string) => {
    try {
      const request = await axios.delete(
        `${process.env.REACT_APP_URL}/api/v1/orders/${id}`,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("userToken")}`,
            "Content-Type": "application/json",
          },
        }
      )
      return id
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

const orderSlice = createSlice({
  name: "order",
  initialState: initialState,
  reducers: {
    clearOrderStore: (state) => {
      return initialState
    },
    clearOrderError: (state) => {
      state.error = initialState.error
    },
  },
  extraReducers: (build) => {
    build
      .addCase(fetchAllOrders.pending, (state, ation) => {
        state.loading = true
      })
      .addCase(fetchAllOrders.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            message:
              action.payload.response?.statusText ||
              "Internal Server Error during fetching all orders.",
            statusCode: action.payload.response?.status,
          }
        } else {
          state.orders = action.payload
        }
        state.loading = false
      })
      .addCase(fetchAllOrders.rejected, (state, action) => {
        state.error = {
          message:
            action.error.message || "Server Error during fetching all orders.",
          statusCode: 500,
        }
        state.loading = false
      })
      .addCase(fetchAllUserOrders.pending, (state, ation) => {
        state.loading = true
      })
      .addCase(fetchAllUserOrders.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            message:
              action.payload.response?.statusText ||
              "Internal Server Error during fetching user orders.",
            statusCode: action.payload.response?.status,
          }
        } else {
          state.orders = action.payload
        }
        state.loading = false
      })
      .addCase(fetchAllUserOrders.rejected, (state, action) => {
        state.error = {
          message:
            action.error.message || "Server Error during fetching user orders.",
          statusCode: 500,
        }
        state.loading = false
      })
      .addCase(createOrder.pending, (state, ation) => {
        state.loading = true
      })
      .addCase(createOrder.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            message:
              action.payload.response?.statusText ||
              "Internal Server Error during creating order.",
            statusCode: action.payload.response?.status,
          }
        } else {
          state.orders.push(action.payload)
        }
        state.loading = false
      })
      .addCase(createOrder.rejected, (state, action) => {
        state.error = {
          message:
            action.error.message || "Server Error during creating order.",
          statusCode: 500,
        }
        state.loading = false
      })
      .addCase(updateOrderStatus.pending, (state, ation) => {
        state.loading = true
      })
      .addCase(updateOrderStatus.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            message:
              action.payload.response?.statusText ||
              "Internal Server Error during updating order status.",
            statusCode: action.payload.response?.status,
          }
        } else {
          const returndata = action.payload as { status: number; id: string }
          const index = state.orders.findIndex(
            (order) => order.id === returndata.id
          )
          state.orders[index].status = returndata.status.toString()
        }
        state.loading = false
      })
      .addCase(updateOrderStatus.rejected, (state, action) => {
        state.error = {
          message:
            action.error.message ||
            "Server Error during updating order status.",
          statusCode: 500,
        }
        state.loading = false
      })
      .addCase(cancelOrder.pending, (state, ation) => {
        state.loading = true
      })
      .addCase(cancelOrder.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            message:
              action.payload.response?.statusText ||
              "Internal Server Error during canceling order.",
            statusCode: action.payload.response?.status,
          }
        } else {
          state.orders = state.orders.filter(
            (order) => order.id !== action.payload
          )
        }
        state.loading = false
      })
      .addCase(cancelOrder.rejected, (state, action) => {
        state.error = {
          message:
            action.error.message || "Server Error during canceling order.",
          statusCode: 500,
        }
        state.loading = false
      })
  },
})

const orderReducer = orderSlice.reducer
export const { clearOrderStore, clearOrderError } = orderSlice.actions
export default orderReducer
