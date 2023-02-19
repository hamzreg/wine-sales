<template>
  <div class="catalog-item">
    <img src="@/assets/img/wineBottle.svg" height="250"/>
    <div class="form-rowCatalog">
      <Text font-size="var(--little-text)" color="var(--green-color)">
        {{ wine.kind }}
      </Text>
      <Text font-size="var(--little-text)" color="var(--green-color)">
        {{ wine.color }}
      </Text>
    </div>
    <div class="form-rowCatalog">
      <Text font-size="var(--little-text)" color="var(--green-color)">
        {{ wine.sugar }}
      </Text>
      <Text font-size="var(--little-text)" color="var(--green-color)">
        {{ wine.volume }} л.
      </Text>
    </div>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ Math.round(supplierWine.price * (1 + supplierWine.percent / 100)) }} ₽
		</Text>
    <div v-if="isInRole == 'customer'">
      <div class="form-rowCatalog">
        <Button>
          Купить
        </Button>
        <Button>
          Поставщик
        </Button>
      </div>
    </div>
  </div>
</template>
  
  
<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'
import WineInterface from '@/Interfaces/WineInterface'
import auth from '@/authentificationService'
import Button from '@/components/button/Button.vue'
    
export default defineComponent({
  name: "CatalogItem",
  components: {
    Text,
    Button
  },
  props: {
    supplierWine: {
      type: Object,
      required: true
    }
  },
  computed: {
    isInRole () {
        return auth.getCurrentUser().role;
    }
  },
  data() {
    return {
      wine: ''
    }
  },
  mounted() {
    WineInterface.getById(this.supplierWine["wineID"]).then(json => {this.wine = json.data});
  },
})
</script>
  
  
<style scoped>
.catalog-item {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  padding: 5px;
  gap: 10px;
}

.form-rowCatalog {
  display: flex;
  flex-direction: row;
  gap: 10%;
  justify-content: center;
  width: 40%;
}
</style>