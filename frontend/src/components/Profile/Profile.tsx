import { useState } from "react"
import { Button, CardMedia, useTheme } from "@mui/material"

import ContainerProductCategory, {
  DisplayGrid,
} from "../../themes/categoryTheme"
import {
  DisplayCardHorizontal,
  HorizontalCardBox,
} from "../../themes/horizontalCardTheme"
import { useAppSelector } from "../../hooks/useAppSelector"

import { ErrorComponent } from "../Common/ErrorComponent"
import { PasswordUpdateForm } from "./PasswordUpdateForm"
import { UserUpdateForm } from "./UserUpdateForm"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import { deleteUser } from "../../redux/reducers/userReducer"
import { useNavigate } from "react-router-dom"

const Profile = () => {
  const { currentUser, error } = useAppSelector((store) => store.user)
  const theme = useTheme()
  const [image, setImage] = useState(currentUser?.imageURL)
  const dispatch = useAppDispatch()
  const navigate = useNavigate()

  const handleProfileDelete = () => {
    if (currentUser === undefined) return alert("Please login to continue")
    alert("Profile Delete Confirm?")
    dispatch(deleteUser(currentUser.id))
    alert("Profile Deleted. Redirecting to Home Page.")
    navigate("/")
  }

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
          <aside id="image-handling" style={{ width: "50%", height: "100%" }}>
            <CardMedia
              component="img"
              image={image ? image : ""}
              alt={currentUser?.firstName}
              sx={{
                [theme.breakpoints.down("md")]: {
                  display: "none",
                },
                height: "100%",
              }}
            />
          </aside>

          <HorizontalCardBox sx={{ width: "50%" }}>
            {error.message && (
              <ErrorComponent
                message={error.message}
                statusCode={error.statusCode}
              />
            )}
            <UserUpdateForm currentUser={currentUser} setImage={setImage} />
            <PasswordUpdateForm theme={theme} currentUser={currentUser} />
            <Button
              variant="contained"
              color="error"
              onClick={handleProfileDelete}
            >
              Delete Profile
            </Button>
          </HorizontalCardBox>
        </DisplayCardHorizontal>
      </DisplayGrid>
    </ContainerProductCategory>
  )
}

export default Profile
