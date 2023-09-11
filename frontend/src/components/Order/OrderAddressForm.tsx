import { Button, TextField } from "@mui/material"
import { useEffect, useState } from "react"
import { AxiosError } from "axios"

import { OrderMainItem } from "../../themes/createOrderTheme"
import { useAppSelector } from "../../hooks/useAppSelector"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import {
  clearAddressError,
  createAddress,
  fetchAllUserAddress,
} from "../../redux/reducers/addressReducer"
import { Done } from "@mui/icons-material"
import { AddressType } from "../../types/Address"

export const OrderAddressForm = ({
  setDeliveryAddress,
}: {
  setDeliveryAddress: React.Dispatch<React.SetStateAction<AddressType>>
}) => {
  const [divDisplay, setDivDisplay] = useState(false)
  const [street, setStreet] = useState("")
  const [city, setCity] = useState("")
  const [state, setState] = useState("")
  const [postalCode, setPostalCode] = useState("")
  const [country, setCountry] = useState("")
  const reduxStore = useAppSelector((store) => store)
  const currentUser = reduxStore.user.currentUser
  const userAddresses = reduxStore.address.address
  const dispatch = useAppDispatch()
  const [orderProductConfirmed, setOrderProductConfirmed] = useState(false)

  if (currentUser === undefined) return <div>Loading...</div>

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()

    if (
      street === "" ||
      city === "" ||
      state === "" ||
      postalCode === "" ||
      country === ""
    ) {
      alert("All fields are required")
      return false
    }

    const newAddress = {
      street: street,
      city: city,
      state: state,
      postalCode: postalCode,
      country: country,
      userId: currentUser.id,
    }

    dispatch(createAddress(newAddress)).then((data) => {
      if (data.type === "createAddress/fulfilled") {
        if (data.payload instanceof AxiosError) {
          setTimeout(() => {
            dispatch(clearAddressError())
          }, 3000)
          return false
        } else {
          alert("Address created.")
          return true
        }
      } else {
        alert("Error creating address.")
      }
    })
    setStreet("")
    setCity("")
    setState("")
    setPostalCode("")
    setCountry("")
    setDivDisplay(false)
  }

  return (
    <OrderMainItem>
      <Button sx={{ width: "100%" }} onClick={() => setDivDisplay(!divDisplay)}>
        2. Confirm Address{" "}
        {orderProductConfirmed && <Done sx={{ color: "green" }} />}
      </Button>

      {divDisplay && (
        <div style={{ display: "flex", flexDirection: "row" }}>
          {userAddresses.map((address) => (
            <div key={address.id} style={{ margin: "0 1rem" }}>
              <p>Street: {address.street}</p>
              <p>City: {address.city}</p>
              <p>State: {address.state}</p>
              <p>PostalCode: {address.postalCode}</p>
              <p>Country: {address.country}</p>
              <Button
                onClick={() => {
                  setDeliveryAddress(address)
                  setDivDisplay(false)
                  setOrderProductConfirmed(true)
                }}
                variant="contained"
              >
                Deliver Here
              </Button>
              <Button
                variant="contained"
                color="error"
                onClick={() => console.log("delete")}
              >
                Delete
              </Button>
            </div>
          ))}
        </div>
      )}
      <hr />
      {divDisplay && (
        <div>
          <h3>Create New Address</h3>
          <form
            onSubmit={handleSubmit}
            style={{ display: "flex", flexDirection: "column", width: "50%" }}
          >
            <TextField
              id="create-Form--Street"
              label="Street"
              type="text"
              value={street}
              variant="filled"
              onChange={(e) => setStreet(e.target.value)}
            />
            <TextField
              id="create-Form--City"
              label="City"
              type="text"
              value={city}
              variant="filled"
              onChange={(e) => setCity(e.target.value)}
            />
            <TextField
              id="create-Form--State"
              label="State"
              type="text"
              value={state}
              variant="filled"
              onChange={(e) => setState(e.target.value)}
            />
            <TextField
              id="create-Form--PostalCode"
              label="PostalCode 6 digits"
              type="text"
              inputProps={{ pattern: "[0-9]{6}" }}
              value={postalCode}
              variant="filled"
              onChange={(e) => setPostalCode(e.target.value)}
            />
            <TextField
              id="create-Form--Country"
              label="Country"
              value={country}
              variant="filled"
              onChange={(e) => setCountry(e.target.value)}
            />
            <Button type="submit" variant="contained">
              Create Address
            </Button>
          </form>
        </div>
      )}
    </OrderMainItem>
  )
}
