<template>
  <div>
    <h2>Welcome to Vue To-Do List Application</h2>
    <h3>This is the Admin Dashboard</h3>
    <h4> Create Task </h4>
    <router-link to="/create">Create Task</router-link>
    <ul v-for="task in allTasks" :key="task.Id">
        <li> {{task.taskName}}  --  {{task.taskDeadline}}   --   {{task.taskStatus}} </li>
    </ul>
    
    
  </div>
</template>

<script>
    export default {
        data() {
            return {
                allTasks: []
            }
        },
        mounted() {
            this.GetAllTasks();
        },
        methods: {
            GetAllTasks() {
                fetch("/AllTasks", {
                    method: "GET"
                })
                    .then((response) => response.json())
                    .then((data) => {
                        this.allTasks = data;
                    })
                    .catch(() =>
                        console.log("Can’t access " + url + " response. Blocked by browser?")
                    );
            
            }
        }
    }
</script>

