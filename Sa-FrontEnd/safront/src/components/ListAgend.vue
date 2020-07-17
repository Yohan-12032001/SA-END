<template>
  <div class="lista">
      <br>
      <table class="tabela">
          <thead>
              <tr>
                  <th>Nome</th>
                  <th>CPF</th>
                  <th>Telefone</th>
                  <th>Data</th>
                  <th>Hora</th>
                  <th class="acao">Ações</th>
              </tr>
          </thead>
          <tbody>
              <tr :value="agend.id" v-for="agend in agendamentos" :key="agend.id" class="dados">
                  <td>{{agend.nome}}</td>
                  <td>{{agend.cpf}}</td>
                  <td>{{agend.telefone}}</td>
                  <td>{{agend.day}}/{{agend.month}}/{{agend.year}}</td>
                  <td>{{agend.hora}}</td>
                  <td class="btn"><button class="buttonDel" @click="deletar(agend.id)">Deletar</button></td>
              </tr>
          </tbody>
      </table>


  </div>
</template>

<script>
const axios=require('axios')
export default {
 data: function(){
    return{
        agendamentos:[]
    }
 }, methods: {
     deletar: function(value){
         if(confirm("Tem certeza que deseja exluir?")){
             axios.delete(`https://localhost:44396/api/Agendamento/${value}`).then(resp=>alert(resp.data));
         
         for(var i=0; i<4;i++){
             axios.get("https://localhost:44396/api/Agendamento").then(agend =>this.agendamentos=agend.data) 
         }
         }
           
     }
 }, mounted(){
     axios.get("https://localhost:44396/api/Agendamento").then(agend =>this.agendamentos=agend.data)   
 }
}
</script>

<style>
.btn{
    padding: 0 30px;
}
.buttonDel{
  background-color: #008CBA; /* Red */
}
table {
  border-collapse: collapse;
  width: 100%;
}

th, td {
  padding: 8px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}
.acao{
    padding: 0 0 0 70px;
}
tr:hover {background-color:#f5f5f5;}
</style>