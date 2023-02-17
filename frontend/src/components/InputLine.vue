<template>
  <input v-model="data" v-if="name == 'password'" type="password" class="input-line" :style="{fontSize}">
  <input v-model="data" v-else class="input-line" :style="{fontSize}">
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";
export default defineComponent({
name: "InputLine",
data () {
  return {
    data: "",
  }
},
components: {},
props: ['name', 'fontSize'],
watch: { 
  data: function() {
    console.log(this.name, this.data);
    this.$emit(this.name, this.data);
  }
},
// mounted () {
//   this.data = this.setData;
//   console.log("Input Get:", this.setData);
// },
});
</script>

<style scoped>
.input-line {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  background-color: var(--beige-color);
  border: var(--green-color);
  border-radius: 18px;
  padding: 5px 10px;
  font-family: var(--font-name);
}
</style>