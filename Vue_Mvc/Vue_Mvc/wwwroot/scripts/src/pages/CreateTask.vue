<template>
  <div>
    <h1>Welcome to Create Task</h1>
    <router-link to="/">Admin Home</router-link>
    <br />
    <hr />
    <h3>Task Name:</h3>
    <input v-model="task.name" type="text" placeholder="Task Name">
    <br />
    <br />
    <h3>Task Deadline</h3>
    <input v-model="task.deadline" type="text" placeholder="Task Deadline">    
    <br />
    <br />
    <button v-on:click="CreateTask">Create Task</button>
  </div>
</template>

<script>
    export default {
        data() {
            return {
                task: {
                    name: "",
                    deadline: "",
                    status: "Pending"
                }
            }
        },
        methods: {
            CreateTask() {
                fetch("Home/Create", {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({
                        TaskName: this.task.name,
                        TaskDeadline: this.task.deadline,
                        TaskStatus: this.task.status
                    })
                })
                    .then((response) => {
                        console.log(response);
                        if (response.ok == true) {
                            this.$router.push("/");
                        }

                        
                    })
            }

        }
    }
</script>