import { Button, TextField, useTheme } from "@mui/material"
import { useEffect, useState } from "react"

import { UserType } from "../../types/User"
import { clearUserError, updateUser } from "../../redux/reducers/userReducer"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import axios, { AxiosError } from "axios"

export const UserUpdateForm = ({
  currentUser,
  setImage,
}: {
  currentUser: UserType
  setImage: React.Dispatch<React.SetStateAction<string | undefined>>
}) => {
  const [firstName, setFirstName] = useState(currentUser?.firstName)
  const [lastName, setLastName] = useState(currentUser?.lastName)
  const [email, setEmail] = useState(currentUser?.email)
  const [imageURL, setImageURL] = useState(currentUser?.imageURL)
  const theme = useTheme()
  const [emailInfoContainer, setEmailInfoContainer] =
    useState<JSX.Element | null>(null)
  const dispatch = useAppDispatch()
  //   const debounceValue = checkEmailAvailableDebounce(email)

  useEffect(() => {
    const debounceTime = setTimeout(() => {
      checkEmailAvailability()
    }, 500)

    return () => {
      clearTimeout(debounceTime)
    }
  }, [email])

  const checkEmailAvailability = async () => {
    try {
      const response = await axios.get<boolean>(
        `${process.env.REACT_APP_URL}/api/v1/users/checkEmailAvailability/${currentUser.id}/${email}`
      )
      setEmailInfoContainer(
        response.data ? null : (
          <p style={{ fontSize: "14px", color: theme.palette.error.main }}>
            Email is taken.
          </p>
        )
      )
    } catch (e) {
      alert("Error chekcing email.")
    }
  }

  const updateHandler = (e: React.ChangeEvent<unknown>) => {
    e.preventDefault()

    if (emailInfoContainer != null) {
      alert("Choose different email. This email is already taken.")
      return false
    }

    if (!firstName || !lastName || !email || !imageURL) {
      alert("Please fill all the fields.")
      return false
    }

    if (currentUser) {
      const updateData = {
        id: currentUser.id,
        updateData: {
          email: email,
          firstName: firstName,
          lastName: lastName,
          imageUrl: imageURL,
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

  return (
    <form
      style={{ display: "grid", rowGap: "2rem", height: "100%" }}
      id="create-Form"
      onSubmit={updateHandler}
    >
      <TextField
        id="create-Form--FirstName"
        label="FirstName"
        type="string"
        variant="filled"
        value={firstName ? firstName : currentUser?.firstName}
        onChange={(e) => setFirstName(e.target.value)}
      />
      <TextField
        id="create-Form--LastName"
        label="LastName"
        type="string"
        variant="filled"
        value={lastName ? lastName : currentUser?.lastName}
        onChange={(e) => setLastName(e.target.value)}
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
        sx={{ margin: "none" }}
      />
      {email === currentUser.email ? null : emailInfoContainer}
      <TextField
        id="create-Form--image"
        label="ImageURL"
        type="string"
        variant="filled"
        value={currentUser.imageURL}
        onChange={(e) => {
          setImage(e.target.value)
          setImageURL(e.target.value)
        }}
      />
      <Button variant="contained" color="primary" type="submit">
        Update User
      </Button>
    </form>
  )
}
