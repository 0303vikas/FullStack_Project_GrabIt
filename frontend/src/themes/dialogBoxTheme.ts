import {
  Dialog,
  styled,
  DialogTitle,
  DialogActions,
  DialogContent,
  DialogContentText,
} from "@mui/material"

const DialogBoxMainContainer = styled(Dialog)(({ theme }) => ({
  width: "80%",
  height: "80%",
  padding: "10%",
}))

const DialogBoxTitleContainer = styled(DialogTitle)(({ theme }) => ({
  width: "80%",
  padding: "5% 10% 0 10%",
  fontFamily: "Roboto Slab",
  fontSize: theme.typography.h4.fontSize,
}))

const DialogBoxActionsContainer = styled(DialogActions)(({ theme }) => ({
  width: "80%",
  height: "40%",
  padding: "5% 10%",
}))

const DialogBoxContentContainer = styled(DialogContent)(({ theme }) => ({
  border: `${theme.palette.secondary.main} 2px solid`,
  cursor: "pointer",
  borderRadius: theme.shape.borderRadius,
  ":hover": {
    boxShadow: theme.shadows[15],
  },
  width: "inherit",
  height: "inherit",
}))

const DialogBoxContentTextContainer = styled(DialogContentText)(
  ({ theme }) => ({
    height: "50%",
    width: "100%",
  })
)

const DialogBoxImageContainer = styled("img")(({ theme }) => ({
  width: "100%",
  height: "100%",
}))

export {
  DialogBoxMainContainer,
  DialogBoxTitleContainer,
  DialogBoxActionsContainer,
  DialogBoxContentContainer,
  DialogBoxContentTextContainer,
  DialogBoxImageContainer,
}
