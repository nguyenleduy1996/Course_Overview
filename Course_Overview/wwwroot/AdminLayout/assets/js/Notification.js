function deleteTopic(topicID) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Admin/Topic/Delete/' + topicID, // Replace with your actual URL
                type: 'POST',
                success: function (response) {
                    // Xóa dòng trên table khi xóa thành công
                    $('#topicRow_' + topicID).remove();

                    // Hiển thị thông báo thành công
                    Swal.fire({
                        icon: "success",
                        title: "Delete item successfully!",
                        timer: 1500
                    });
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.error("Error deleting item:", textStatus, errorThrown);
                    Swal.fire({
                        icon: "error",
                        title: "Delete item failed",
                        text: "Please try again.",
                        timer: 1500
                    });
                }
            });
        }
    });
}

function deleteCourse(courseID) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Admin/Course/Delete/' + courseID, // Replace with your actual URL
                type: 'POST',
                success: function (response) {
                    // Xóa dòng trên table khi xóa thành công
                    $('#topicRow_' + courseID).remove();

                    // Hiển thị thông báo thành công
                    Swal.fire({
                        icon: "success",
                        title: "Delete item successfully!",
                        timer: 1500
                    });
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.error("Error deleting item:", textStatus, errorThrown);
                    Swal.fire({
                        icon: "error",
                        title: "Delete item failed",
                        text: "Please try again.",
                        timer: 1500
                    });
                }
            });
        }
    });
}

function deleteTeacher(teacherID) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Admin/Teacher/Delete/' + teacherID, // Replace with your actual URL
                type: 'POST',
                success: function (response) {
                    // Xóa dòng trên table khi xóa thành công
                    $('#topicRow_' + teacherID).remove();

                    // Hiển thị thông báo thành công
                    Swal.fire({
                        icon: "success",
                        title: "Delete item successfully!",
                        timer: 1500
                    });
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.error("Error deleting item:", textStatus, errorThrown);
                    Swal.fire({
                        icon: "error",
                        title: "Delete item failed",
                        text: "Please try again.",
                        timer: 1500
                    });
                }
            });
        }
    });
}

function deleteClasses(classID) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Admin/Class/Delete/' + classID, // Replace with your actual URL
                type: 'POST',
                success: function (response) {
                    // Xóa dòng trên table khi xóa thành công
                    $('#topicRow_' + classID).remove();

                    // Hiển thị thông báo thành công
                    Swal.fire({
                        icon: "success",
                        title: "Delete item successfully!",
                        timer: 1500
                    });
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.error("Error deleting item:", textStatus, errorThrown);
                    Swal.fire({
                        icon: "error",
                        title: "Delete item failed",
                        text: "Please try again.",
                        timer: 1500
                    });
                }
            });
        }
    });
}