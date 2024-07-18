$(document).ready(function () {
    $("#courseTable").DataTable({
        "ajax": {
            "url": "/Admin/Course/GetCourses",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "CourseID", "className": "text-center", "width": "1%" },
            {
                "data": "CourseName",
                "className": "text-center ",
                "width": "25%",
                "render": function (data) {
                    return `<h6>${data}</h6>`;
                }
            },
            {
                "data": "ImagePath",
                "className": "text-center",
                "width": "25%",
                "render": function (data) {
                    return `<img src="/${data}" style="width: 150px; height: 150px;" class="img-thumbnail " />`;
                }
            },
            {
                "data": 'CourseID',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                               <a href="/admin/course/update/${data}" class="btn btn-secondary mx-2">
                                                   <i class="bi bi-pencil-square"></i> Edit
                                               </a>                                          
                                            </div>`;
                },
                "width": "20%"
            }
        ]
    });
});