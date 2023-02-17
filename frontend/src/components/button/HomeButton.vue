<template>
  <button class="button">
    <Text fontSize="var(--little-text)" color="var(--green-color)">
      <slot></slot>
    </Text>
  </button>
</template>
  

<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'

export default defineComponent({
  name: "HomeButton",
  components: {
    Text
  }
})
</script>
  

<style>
.button{
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  background-color: var(--beige-color);
  border: var(--beige-color);
  border-radius: 18px;
  padding: 1.2% 3%;
  font-family: var(--font-name);
}
</style>