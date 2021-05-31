<template>
  <div>
    <h2>Welcome to Vue To-Do List Application</h2>
    <h3>This is the Admin Dashboard</h3>

    <router-link to="/create"><h3>Create Task</h3></router-link>

    <!--<ul v-for="task in allTasks" :key="task.Id">
        <li> {{task.taskName}}  --  {{task.taskDeadline}}   --   {{task.taskStatus}} </li>
    </ul>-->

  <table>
      <tr v-for="task in allTasks" :key="task.Id">
          <td style="width: 100px"> {{task.taskName}} </td>
          
          <td style="width: 100px"> {{task.taskDeadline}} </td>
          
          <td style="width: 100px"> {{task.taskStatus}} </td>

          <td>
              <button style="color: green" v-on:click="CompleteTask(task.id)">Complete Task</button>
          </td>
          
          <td>
              <button style="color: red" v-on:click="DeleteTask(task.id)">Delete Task</button>
          </td>
      </tr>
 
  </table>
    
    
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

            },
            CompleteTask(id) {
                fetch("Task/Complete/" + id, {
                    method: "GET"
                })
                    .then((res) => {
                        console.log(res);
                        if (res.status == 200) {
                            this.GetAllTasks();
                        } else {
                            alert("Could Not Delete Due to some problem");
                        }
                    })
                    .catch(() =>
                        console.log("Can’t access " + url + " response. Blocked by browser?")
                    );
            },
            DeleteTask(id) {
                fetch("Task/Delete/" + id, {
                    method: "DELETE"
                })
                    .then((response) => {
                        console.log(response);
                        if (response.status == 200) {
                            this.GetAllTasks();
                        }
                    })
                    .catch(() =>
                        console.log("Can’t access " + url + " response. Blocked by browser?")
                    );
            }
        }
    }
</script>

