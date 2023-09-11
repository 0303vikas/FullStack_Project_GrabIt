import { configureStore } from "@reduxjs/toolkit"

import productReducer from "./reducers/productReducer"
import categoryReducer from "./reducers/categoryReducer"
import cartReducer from "./reducers/cartReducer"
import userReducer from "./reducers/userReducer"
import modeReducer from "./reducers/modeReducer"
import { checkBrowserMode } from "../hooks/reduxMediaModeCheck"
import addressReducer from "./reducers/addressReducer"
import orderReducer from "./reducers/orderReducer"

const storedCart = localStorage.getItem("ProductCart")
const cartData = storedCart !== null ? JSON.parse(storedCart) : []

const modeData = checkBrowserMode()

const store = configureStore({
  reducer: {
    product: productReducer,
    categories: categoryReducer,
    cart: cartReducer,
    user: userReducer,
    address: addressReducer,
    mode: modeReducer,
    order: orderReducer,
  },
  preloadedState: {
    product: {
      products: [],
      loading: false,
      error: "",
    },
    categories: {
      category: [],
      loading: false,
      error: "",
    },
    cart: cartData,
    user: {
      users: [],
      loading: false,
      error: {
        message: "",
        statusCode: 200,
      },
      authloading: true,
    },
    address: {
      address: [],
      loading: false,
      error: {
        message: "",
        statusCode: 200,
      },
    },
    order: {
      orders: [],
      loading: false,
      error: {
        message: "",
        statusCode: 200,
      },
    },
    mode: {
      mode: modeData ? "dark" : "light",
    },
  },
})

store.subscribe(() => {
  localStorage.setItem("ProductCart", JSON.stringify(store.getState().cart))
})

export type GlobalStoreState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch

export default store
