window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful", { timeOut: 2000 });
    }
    if (type === "error") {
        toastr.error(message, "Operation Failed", { timeOut: 2000 });
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success Notification!',
            message,
            'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Error Notification!',
            message,
            'error'
        )
    }
}

function ShowDeleteConfirmationModal() {
    $('#DeleteModal').modal('show');
}
function HideDeleteConfirmationModal() {
    $('#DeleteModal').modal('hide');
}

window.generatePDF = () => {
    const { jsPDF } = window.jspdf;
    const getFormattedDate = () => {
        const date = new Date();
        const year = date.getFullYear();
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const day = String(date.getDate()).padStart(2, '0');
        return `${day}-${month}-${year}`;
    };
    html2canvas(document.querySelector("#pdfContent")).then(canvas => {
        const imgData = canvas.toDataURL('image/png');
        const pdf = new jsPDF('p', 'mm', 'a4');
        const imgProps = pdf.getImageProperties(imgData);
        const pdfWidth = pdf.internal.pageSize.getWidth();
        const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;
        pdf.addImage(imgData, 'PNG', 0, 0, pdfWidth, pdfHeight);
        const fileName = `report_${getFormattedDate()}.pdf`;
        pdf.save(fileName);
    });
};

document.addEventListener('DOMContentLoaded', function () {
    AOS.init();
});