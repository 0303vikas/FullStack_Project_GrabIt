import { useEffect, useState } from "react"
import { Button, CardMedia, Input, TextField, useTheme } from "@mui/material"

import ContainerProductCategory, {
  DisplayGrid,
} from "../../themes/categoryTheme"
import {
  DisplayCardHorizontal,
  HorizontalCardBox,
} from "../../themes/horizontalCardTheme"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import { useAppSelector } from "../../hooks/useAppSelector"
import {
  clearUserError,
  fetchAllUsers,
  updateUser,
} from "../../redux/reducers/userReducer"
import { Controller, SubmitHandler, useForm } from "react-hook-form"
import { ErrorComponent } from "../ErrorComponent"
import { PasswordUpdateForm } from "./PasswordUpdateForm"
import { AxiosError } from "axios"

const Profile = () => {
  const { currentUser, users, error } = useAppSelector((store) => store.user)
  const theme = useTheme()
  const [image, setImage] = useState(currentUser?.imageURL)
  const [firstName, setFirstName] = useState(currentUser?.firstName)
  const [lastName, setLastName] = useState(currentUser?.lastName)
  const [email, setEmail] = useState(currentUser?.email)
  const [emailError, setEmailError] = useState("")

  const dispatch = useAppDispatch()

  const updateHandler = () => {
    if (currentUser?.email !== email) {
      if (users.find((item) => item.email === email)) {
        setEmailError("Email Already Exists")
        return
      }
    }
    if (currentUser) {
      const updateData = {
        id: currentUser.id,
        updateData: {
          email: email,
          firstName: firstName,
          lastName: lastName,
          imageUrl: image,
        },
      }
      dispatch(updateUser(updateData)).then((data) => {
        if (data.type === "updateUser/fulfilled") {
          if (data.payload instanceof AxiosError) {
            setTimeout(() => {
              dispatch(clearUserError())
            }, 3000)
            return false
          } else {
            alert("User Updated Successfully.")
          }
        }
      })
    }
  }

  // const addImage = (arg: string) => {
  //   setImage(arg)
  //   alert("Image added Successfully.")
  // }

  if (currentUser === undefined) return <div>Loading...</div>

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
          P
        </span>
        rofile
      </h1>

      <DisplayGrid gap={2} gridTemplateColumns={"repeat(1,1fr)"}>
        <DisplayCardHorizontal>
          <aside id="image-handling">
            <CardMedia
              component="img"
              height="400"
              image={image ? image : ""}
              alt={firstName ? firstName + " image." : "Category Image."}
              sx={{
                [theme.breakpoints.down("md")]: {
                  display: "none",
                },
              }}
            />
          </aside>

          <HorizontalCardBox>
            {error.message && (
              <ErrorComponent
                message={error.message}
                statusCode={error.statusCode}
              />
            )}
            <form
              style={{ display: "grid", rowGap: "2rem", height: "100%" }}
              id="create-Form"
            >
              <TextField
                id="create-Form--FirstName"
                label="FirstName"
                type="string"
                variant="filled"
                value={firstName ? firstName : currentUser?.firstName}
                onChange={(e) => setFirstName(e.target.value)}
                onClick={() => setEmailError("")}
              />
              <TextField
                id="create-Form--LastName"
                label="LastName"
                type="string"
                variant="filled"
                value={lastName ? lastName : currentUser?.lastName}
                onChange={(e) => setLastName(e.target.value)}
                onClick={() => setEmailError("")}
              />
              <TextField
                id="create-Form--email"
                label="Email"
                type="email"
                variant="filled"
                value={email ? email : currentUser?.email}
                onChange={(e) => {
                  setEmail(e.target.value)
                }}
              />
              {emailError && (
                <p style={{ color: theme.palette.error.main }}>{emailError}</p>
              )}
              <Button variant="contained" color="primary" type="submit">
                Update User
              </Button>
            </form>
            <PasswordUpdateForm theme={theme} currentUser={currentUser} />
          </HorizontalCardBox>
        </DisplayCardHorizontal>
      </DisplayGrid>
    </ContainerProductCategory>
  )
}

export default Profile
