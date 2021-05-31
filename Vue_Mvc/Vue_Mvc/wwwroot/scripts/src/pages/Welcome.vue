<template>
    <div>
        <h1>Welcome to Vue To-Do List Application</h1>
        <h2>This is User Home Page</h2>
        <a href="/Home/Login"><h3>Logout</h3></a>
        <!--<ul v-for="task in pendingTasks" :key="task.Id">
        <li> {{task.taskName}}    --    {{task.taskDeadline}}   --    {{task.taskStatus}} </li>
    </ul>
    -->

        <table>
            <tr v-for="task in pendingTasks">
                <td style="width: 100px"> {{task.taskName}} </td>

                <td style="width: 100px"> {{task.taskDeadline}} </td>

                <td style="width: 100px"> {{task.taskStatus}} </td>
                
                <td>
                    <button style="color: green" v-on:click="CompleteTask(task.id)">Complete Task</button>
                </td>

                
            </tr>

        </table>

    </div>
</template>

<script>
    export default {
        data() {
            return {
                pendingTasks: [],
                
            }
        },
        mounted() {
            this.GetTasks();
        },
        methods: {
            GetTasks() {
                fetch("/Pendings", {
                    method: "GET"
                })
                    .then((response) => response.json())
                    .then((data) => {
                        this.pendingTasks = data;
                    })
                    .catch(() =>
                        console.log("Can’t access " + url + " response. Blocked by browser?")
                    );
            
            },
            CompleteTask(id) {
                fetch("/Task/Complete/" + id, {
                    method: "GET"
                })
                    .then((res) => {
                        console.log(res);
                        if (res.status == 200) {
                            this.GetTasks();
                        } else {
                            alert("Couldn't complete the request");
                        }
                    })
                    .catch(() =>
                        console.log("Can’t access " + url + " response. Blocked by browser?")
                    );
            }
        }
    }
</script>

