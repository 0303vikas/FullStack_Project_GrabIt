import { Button, Slide } from "@mui/material"
import { TransitionProps } from "@mui/material/transitions"
import React from "react"

import productImage from "../../icons/Product.png"
import categoryImage from "../../icons/Category.png"
import {
  DialogBoxActionsContainer,
  DialogBoxContentContainer,
  DialogBoxImageContainer,
  DialogBoxMainContainer,
  DialogBoxTitleContainer,
} from "../../themes/dialogBoxTheme"
import { useAppSelector } from "../../hooks/useAppSelector"
import { useNavigate } from "react-router-dom"

const Transition = React.forwardRef(function Transition(
  props: TransitionProps & {
    children: React.ReactElement<any, any>
  },
  ref: React.Ref<unknown>
) {
  return <Slide direction="up" ref={ref} {...props} />
})

export const CreateDialogBox = () => {
  const [open, setOpen] = React.useState(false)
  const { currentUser } = useAppSelector((store) => store.user)
  const navigate = useNavigate()

  const handleClickOpen = () => {
    setOpen(true)
  }

  const handleClose = () => {
    setOpen(false)
  }
  if ((currentUser && currentUser.role !== 0) || !currentUser) return null

  return (
    <div>
      <Button variant="outlined" onClick={handleClickOpen}>
        + Create
      </Button>
      <DialogBoxMainContainer
        open={open}
        TransitionComponent={Transition}
        keepMounted
        onClose={handleClose}
        aria-describedby="alert-dialog-slide-description"
      >
        <DialogBoxTitleContainer>
          {"What would you like to create?"}
        </DialogBoxTitleContainer>

        <DialogBoxActionsContainer>
          <DialogBoxContentContainer onClick={() => navigate("/createproduct")}>
            <DialogBoxImageContainer src={productImage} />
            <DialogBoxTitleContainer id="alert-dialog-slide-description">
              Product
            </DialogBoxTitleContainer>
          </DialogBoxContentContainer>
          <DialogBoxContentContainer
            onClick={() => navigate("/createcategory")}
          >
            <DialogBoxImageContainer src={categoryImage} />
            <DialogBoxTitleContainer id="alert-dialog-slide-description">
              Category
            </DialogBoxTitleContainer>
          </DialogBoxContentContainer>
        </DialogBoxActionsContainer>
      </DialogBoxMainContainer>
    </div>
  )
}
