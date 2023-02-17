<template>
  <input v-model="data" v-if="name == 'password'" type="password" class="input-line" :style="{fontSize}" :placeholder="placeholderText">
  <input v-model="data" v-else class="input-line" :style="{fontSize}" :placeholder="placeholderText">
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
props: ['name', 'fontSize', 'placeholderText'],
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
  border: none;
  border-radius: 18px;
  padding: 2px 10px;
  min-width: 120px;
  font-family: var(--font-name);
  outline: none;
}
</style>