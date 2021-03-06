import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';


const DeleteConfirmation = ({ showModal, hideModal, confirmModal }) => {
    return (
        <Dialog
        open={showModal}
        onClose={hideModal}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          Подтверждение удаления
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Вы уверены что хотите удалить?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={hideModal}>Отменить</Button>
          <Button onClick={confirmModal} autoFocus>
            Удалить
          </Button>
        </DialogActions>
      </Dialog>
    )
}

export default DeleteConfirmation;