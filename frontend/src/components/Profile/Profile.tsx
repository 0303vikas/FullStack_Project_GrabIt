import { useState } from "react"
import { CardMedia, useTheme } from "@mui/material"

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

const Profile = () => {
  const { currentUser, error } = useAppSelector((store) => store.user)
  const theme = useTheme()
  const [image, setImage] = useState(currentUser?.imageURL)

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
          </HorizontalCardBox>
        </DisplayCardHorizontal>
      </DisplayGrid>
    </ContainerProductCategory>
  )
}

export default Profile
