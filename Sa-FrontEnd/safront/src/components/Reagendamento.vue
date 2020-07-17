<template>

    <div class="Reagendamento">
        <div class="pesquisa">
        <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

        <b>CPF: </b>
        <input type="text" placeholder="Digite o CPF" v-model="cpfPes">
        <button class="fa fa-search" id="buton" @click="pesquisa"></button><br><br>

        <div v-if="respArray==true">
            <b class="font">Agendamento Encontrado</b><br>
            <b>Escolha uma nova Data e Hora</b><br><br>
        <b>Hora: </b>
        <input type="time" v-model="hora" ><br><br>

        <b>Data: </b>
        <input type="date" v-model="data"><br><br>
        </div>
        
        </div>
        <button class="Enviar" @click="enviar">Enviar</button>
    </div>
        
</template>

<script>
const axios= require('axios')
export default {
    data: function(){
        return{
            cpfPes:'',
            hora:'',
            data:'',

            idArray:0,
            agendamentos:[],
            respArray:false,

            cpf:'',
            nome:'',
            telefone:''

        }
    }, methods:{
        pesquisa:function(){
            if(this.cpfPes==""){
                return alert("Preencha os Campos")
            }
            var pesquisa=this.agendamentos.find(element => element.cpf==this.cpfPes)
            if(pesquisa != undefined){
                this.idArray=pesquisa.id
                this.nome=pesquisa.nome
                this.cpf=pesquisa.cpf
                this.telefone=pesquisa.telefone

                this.respArray=true
            }
        },
        enviar:function(){
            if(this.idArray>0){
                axios.put(`https://localhost:44396/api/Agendamento/${this.idArray}`,{
                    data:this.data,
                    hora:this.hora,
                    cpf:this.cpf,
                    telefone:this.telefone,
                    nome:this.nome,
                }).then(resp=>alert(resp.data))
            }
        }
    },mounted(){
        axios.get("https://localhost:44396/api/Agendamento").then(resp=>this.agendamentos=resp.data)
    }
}
</script>

<style>
#buton{
  background-color: #008CBA; /* Green */
  border: none;
  border-radius: 5px;
  color: white;
  text-decoration: none;
  display: inline-block;
  font-size: 10 px;
  cursor: pointer;
  margin-top: 5px;
  width: 40px;
  height: 30px;
}
.pesquisa{
    margin-right:50px ;
}
.Enviar{
    padding: 0px 0px 2px 0px;
}
.font{
    color: #4CAF50;
}
</style>