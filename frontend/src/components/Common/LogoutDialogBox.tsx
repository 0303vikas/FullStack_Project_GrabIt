import { Button } from "@mui/material"
import {
  DialogBoxActionsContainer,
  DialogBoxMainContainer,
  DialogBoxTitleContainer,
} from "../../themes/dialogBoxTheme"

export const LogoutDialogBox = ({
  setopenLogoutConfirm,
  openLogoutConfirm,
  logout,
}: {
  setopenLogoutConfirm: React.Dispatch<React.SetStateAction<boolean>>
  openLogoutConfirm: boolean
  logout: () => void
}) => {
  return (
    <DialogBoxMainContainer
      open={openLogoutConfirm}
      keepMounted
      onClose={() => setopenLogoutConfirm(false)}
      aria-describedby="logout-confimation"
    >
      <DialogBoxTitleContainer>{"Confirm Logout?"}</DialogBoxTitleContainer>
      <DialogBoxActionsContainer>
        <Button onClick={() => setopenLogoutConfirm(false)}>Cancel</Button>
        <Button color="error" onClick={logout}>
          Confirm
        </Button>
      </DialogBoxActionsContainer>
    </DialogBoxMainContainer>
  )
}
