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
        <Button v-on:click="createSale">
          Купить
        </Button>
    </div>
  </div>
</template>
  
  
<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'
import WineInterface from '@/Interfaces/WineInterface'
import { Sale } from '@/Interfaces/SaleInterface'
import SaleInterface from '@/Interfaces/SaleInterface'
import auth from '@/authentificationService'
import Button from '@/components/button/Button.vue'
import router from "@/router"
    
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
  methods: {
    async createSale() {
      const sale: Sale = {
        customerId: auth.getCurrentUser().roleId,
        supplierWineId: this.supplierWine.id,
        sellingPrice: Math.round(this.supplierWine.price * (1 + this.supplierWine.percent / 100)),
        purchasePrice: this.supplierWine.price,
        profit: (Math.round(this.supplierWine.price * (1 + this.supplierWine.percent / 100)) - this.supplierWine.price),
        wineNumber: 1,
      }

      console.log(sale);

      const saleResult = await SaleInterface.post(sale);
      console.log(saleResult.status)

      if (saleResult.status == 200) {
        this.$notify({
          title: "Успех.",
          text: "Вы купили вино.",
        });
      }
    }
  }
})
</script>
  
  
<style scoped>
.catalog-item {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  padding: 20px;
  gap: 10px;
}

.form-rowCatalog {
  display: flex;
  flex-direction: row;
  gap: 10%;
  justify-content: center;
  width: 60%;
}
</style>