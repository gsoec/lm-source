.class Lcom/google/payment/IabHelper$4;
.super Ljava/lang/Object;
.source "IabHelper.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/payment/IabHelper;->queryInventoryAsync(Ljava/util/ArrayList;Lcom/google/payment/IabHelper$QueryInventoryListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/google/payment/IabHelper;

.field final synthetic val$handler:Landroid/os/Handler;

.field final synthetic val$items:Ljava/util/ArrayList;

.field final synthetic val$listener:Lcom/google/payment/IabHelper$QueryInventoryListener;


# direct methods
.method constructor <init>(Lcom/google/payment/IabHelper;Ljava/util/ArrayList;Lcom/google/payment/IabHelper$QueryInventoryListener;Landroid/os/Handler;)V
    .locals 0
    .param p1, "this$0"    # Lcom/google/payment/IabHelper;

    .prologue
    .line 841
    iput-object p1, p0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    iput-object p2, p0, Lcom/google/payment/IabHelper$4;->val$items:Ljava/util/ArrayList;

    iput-object p3, p0, Lcom/google/payment/IabHelper$4;->val$listener:Lcom/google/payment/IabHelper$QueryInventoryListener;

    iput-object p4, p0, Lcom/google/payment/IabHelper$4;->val$handler:Landroid/os/Handler;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 25

    .prologue
    .line 843
    new-instance v4, Ljava/util/ArrayList;

    invoke-direct {v4}, Ljava/util/ArrayList;-><init>()V

    .line 844
    .local v4, "cardIds":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    const/4 v8, 0x0

    .local v8, "i":I
    :goto_0
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$items:Ljava/util/ArrayList;

    move-object/from16 v21, v0

    invoke-virtual/range {v21 .. v21}, Ljava/util/ArrayList;->size()I

    move-result v21

    move/from16 v0, v21

    if-ge v8, v0, :cond_0

    .line 845
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$items:Ljava/util/ArrayList;

    move-object/from16 v21, v0

    move-object/from16 v0, v21

    invoke-virtual {v0, v8}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Lcom/igg/sdk/payment/bean/IGGGameItem;

    .line 846
    .local v9, "item":Lcom/igg/sdk/payment/bean/IGGGameItem;
    invoke-virtual {v9}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getId()Ljava/lang/Integer;

    move-result-object v21

    invoke-static/range {v21 .. v21}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v21

    move-object/from16 v0, v21

    invoke-virtual {v4, v0}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 844
    add-int/lit8 v8, v8, 0x1

    goto :goto_0

    .line 849
    .end local v9    # "item":Lcom/igg/sdk/payment/bean/IGGGameItem;
    :cond_0
    const/16 v19, 0x14

    .line 851
    .local v19, "timeCount":I
    invoke-virtual {v4}, Ljava/util/ArrayList;->size()I

    move-result v21

    div-int v5, v21, v19

    .line 852
    .local v5, "count":I
    invoke-virtual {v4}, Ljava/util/ArrayList;->size()I

    move-result v21

    rem-int v12, v21, v19

    .line 854
    .local v12, "remain":I
    if-eqz v12, :cond_1

    .line 855
    add-int/lit8 v5, v5, 0x1

    .line 858
    :cond_1
    const/4 v15, 0x0

    .local v15, "s":I
    :goto_1
    if-ge v15, v5, :cond_b

    .line 859
    new-instance v10, Ljava/util/ArrayList;

    invoke-direct {v10}, Ljava/util/ArrayList;-><init>()V

    .line 860
    .local v10, "list":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    mul-int v17, v15, v19

    .local v17, "t":I
    :goto_2
    mul-int v21, v15, v19

    add-int v21, v21, v19

    move/from16 v0, v17

    move/from16 v1, v21

    if-ge v0, v1, :cond_2

    .line 861
    invoke-virtual {v4}, Ljava/util/ArrayList;->size()I

    move-result v21

    move/from16 v0, v17

    move/from16 v1, v21

    if-lt v0, v1, :cond_3

    .line 869
    :cond_2
    const/16 v20, 0x0

    .local v20, "x":I
    :goto_3
    invoke-virtual {v10}, Ljava/util/ArrayList;->size()I

    move-result v21

    move/from16 v0, v20

    move/from16 v1, v21

    if-ge v0, v1, :cond_4

    .line 870
    const-string v22, "queryInventoryAsync"

    new-instance v21, Ljava/lang/StringBuilder;

    invoke-direct/range {v21 .. v21}, Ljava/lang/StringBuilder;-><init>()V

    const-string v23, "====="

    move-object/from16 v0, v21

    move-object/from16 v1, v23

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v21

    move-object/from16 v0, v21

    invoke-virtual {v0, v15}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v21

    const-string v23, "====SkuDetails ID\uff1a "

    move-object/from16 v0, v21

    move-object/from16 v1, v23

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v23

    move/from16 v0, v20

    invoke-virtual {v10, v0}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v21

    check-cast v21, Ljava/lang/String;

    move-object/from16 v0, v23

    move-object/from16 v1, v21

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v21

    invoke-virtual/range {v21 .. v21}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v21

    move-object/from16 v0, v22

    move-object/from16 v1, v21

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 869
    add-int/lit8 v20, v20, 0x1

    goto :goto_3

    .line 865
    .end local v20    # "x":I
    :cond_3
    move/from16 v0, v17

    invoke-virtual {v4, v0}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v21

    move-object/from16 v0, v21

    invoke-virtual {v10, v0}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 860
    add-int/lit8 v17, v17, 0x1

    goto :goto_2

    .line 873
    .restart local v20    # "x":I
    :cond_4
    new-instance v11, Landroid/os/Bundle;

    invoke-direct {v11}, Landroid/os/Bundle;-><init>()V

    .line 874
    .local v11, "querySkus":Landroid/os/Bundle;
    const-string v21, "ITEM_ID_LIST"

    move-object/from16 v0, v21

    invoke-virtual {v11, v0, v10}, Landroid/os/Bundle;->putStringArrayList(Ljava/lang/String;Ljava/util/ArrayList;)V

    .line 876
    :try_start_0
    const-string v21, "queryInventoryAsync"

    const-string v22, "Get Google Play Price start"

    invoke-static/range {v21 .. v22}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 877
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    move-object/from16 v21, v0

    move-object/from16 v0, v21

    iget-object v0, v0, Lcom/google/payment/IabHelper;->mService:Lcom/android/vending/billing/IInAppBillingService;

    move-object/from16 v21, v0

    const/16 v22, 0x3

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    move-object/from16 v23, v0

    move-object/from16 v0, v23

    iget-object v0, v0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    move-object/from16 v23, v0

    invoke-virtual/range {v23 .. v23}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v23

    const-string v24, "inapp"

    move-object/from16 v0, v21

    move/from16 v1, v22

    move-object/from16 v2, v23

    move-object/from16 v3, v24

    invoke-interface {v0, v1, v2, v3, v11}, Lcom/android/vending/billing/IInAppBillingService;->getSkuDetails(ILjava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v16

    .line 878
    .local v16, "skuDetails":Landroid/os/Bundle;
    const-string v21, "queryInventoryAsync"

    const-string v22, "Get Google Play Price end"

    invoke-static/range {v21 .. v22}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 880
    const-string v21, "DETAILS_LIST"

    move-object/from16 v0, v16

    move-object/from16 v1, v21

    invoke-virtual {v0, v1}, Landroid/os/Bundle;->containsKey(Ljava/lang/String;)Z

    move-result v21

    if-nez v21, :cond_6

    .line 881
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    move-object/from16 v21, v0

    invoke-virtual/range {v21 .. v21}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 882
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    move-object/from16 v21, v0

    move-object/from16 v0, v21

    iget-boolean v0, v0, Lcom/google/payment/IabHelper;->mDisposed:Z

    move/from16 v21, v0

    if-nez v21, :cond_5

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$listener:Lcom/google/payment/IabHelper$QueryInventoryListener;

    move-object/from16 v21, v0

    if-eqz v21, :cond_5

    .line 883
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$handler:Landroid/os/Handler;

    move-object/from16 v21, v0

    new-instance v22, Lcom/google/payment/IabHelper$4$1;

    move-object/from16 v0, v22

    move-object/from16 v1, p0

    invoke-direct {v0, v1}, Lcom/google/payment/IabHelper$4$1;-><init>(Lcom/google/payment/IabHelper$4;)V

    invoke-virtual/range {v21 .. v22}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    .line 950
    .end local v10    # "list":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    .end local v11    # "querySkus":Landroid/os/Bundle;
    .end local v16    # "skuDetails":Landroid/os/Bundle;
    .end local v17    # "t":I
    .end local v20    # "x":I
    :cond_5
    :goto_4
    return-void

    .line 895
    .restart local v10    # "list":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    .restart local v11    # "querySkus":Landroid/os/Bundle;
    .restart local v16    # "skuDetails":Landroid/os/Bundle;
    .restart local v17    # "t":I
    .restart local v20    # "x":I
    :cond_6
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    move-object/from16 v21, v0

    move-object/from16 v0, v21

    move-object/from16 v1, v16

    invoke-virtual {v0, v1}, Lcom/google/payment/IabHelper;->getResponseCodeFromBundle(Landroid/os/Bundle;)I

    move-result v13

    .line 896
    .local v13, "response":I
    if-eqz v13, :cond_7

    .line 897
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    move-object/from16 v21, v0

    invoke-virtual/range {v21 .. v21}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 898
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    move-object/from16 v21, v0

    move-object/from16 v0, v21

    iget-boolean v0, v0, Lcom/google/payment/IabHelper;->mDisposed:Z

    move/from16 v21, v0

    if-nez v21, :cond_5

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$listener:Lcom/google/payment/IabHelper$QueryInventoryListener;

    move-object/from16 v21, v0

    if-eqz v21, :cond_5

    .line 899
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$handler:Landroid/os/Handler;

    move-object/from16 v21, v0

    new-instance v22, Lcom/google/payment/IabHelper$4$2;

    move-object/from16 v0, v22

    move-object/from16 v1, p0

    invoke-direct {v0, v1}, Lcom/google/payment/IabHelper$4$2;-><init>(Lcom/google/payment/IabHelper$4;)V

    invoke-virtual/range {v21 .. v22}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_4

    .line 925
    .end local v13    # "response":I
    .end local v16    # "skuDetails":Landroid/os/Bundle;
    :catch_0
    move-exception v7

    .line 926
    .local v7, "e":Ljava/lang/Exception;
    invoke-virtual {v7}, Ljava/lang/Exception;->printStackTrace()V

    .line 927
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    move-object/from16 v21, v0

    invoke-virtual/range {v21 .. v21}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 928
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    move-object/from16 v21, v0

    move-object/from16 v0, v21

    iget-boolean v0, v0, Lcom/google/payment/IabHelper;->mDisposed:Z

    move/from16 v21, v0

    if-nez v21, :cond_5

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$listener:Lcom/google/payment/IabHelper$QueryInventoryListener;

    move-object/from16 v21, v0

    if-eqz v21, :cond_5

    .line 929
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$handler:Landroid/os/Handler;

    move-object/from16 v21, v0

    new-instance v22, Lcom/google/payment/IabHelper$4$3;

    move-object/from16 v0, v22

    move-object/from16 v1, p0

    invoke-direct {v0, v1}, Lcom/google/payment/IabHelper$4$3;-><init>(Lcom/google/payment/IabHelper$4;)V

    invoke-virtual/range {v21 .. v22}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    goto :goto_4

    .line 910
    .end local v7    # "e":Ljava/lang/Exception;
    .restart local v13    # "response":I
    .restart local v16    # "skuDetails":Landroid/os/Bundle;
    :cond_7
    :try_start_1
    const-string v21, "DETAILS_LIST"

    move-object/from16 v0, v16

    move-object/from16 v1, v21

    invoke-virtual {v0, v1}, Landroid/os/Bundle;->getStringArrayList(Ljava/lang/String;)Ljava/util/ArrayList;

    move-result-object v14

    .line 911
    .local v14, "responseList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    if-eqz v14, :cond_a

    .line 912
    invoke-virtual {v14}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v21

    :cond_8
    invoke-interface/range {v21 .. v21}, Ljava/util/Iterator;->hasNext()Z

    move-result v22

    if-eqz v22, :cond_a

    invoke-interface/range {v21 .. v21}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v18

    check-cast v18, Ljava/lang/String;

    .line 913
    .local v18, "thisResponse":Ljava/lang/String;
    new-instance v6, Lcom/google/payment/SkuDetails;

    move-object/from16 v0, v18

    invoke-direct {v6, v0}, Lcom/google/payment/SkuDetails;-><init>(Ljava/lang/String;)V

    .line 914
    .local v6, "d":Lcom/google/payment/SkuDetails;
    const/4 v8, 0x0

    :goto_5
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$items:Ljava/util/ArrayList;

    move-object/from16 v22, v0

    invoke-virtual/range {v22 .. v22}, Ljava/util/ArrayList;->size()I

    move-result v22

    move/from16 v0, v22

    if-ge v8, v0, :cond_8

    .line 915
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$items:Ljava/util/ArrayList;

    move-object/from16 v22, v0

    move-object/from16 v0, v22

    invoke-virtual {v0, v8}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Lcom/igg/sdk/payment/bean/IGGGameItem;

    .line 916
    .restart local v9    # "item":Lcom/igg/sdk/payment/bean/IGGGameItem;
    invoke-virtual {v9}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getId()Ljava/lang/Integer;

    move-result-object v22

    invoke-static/range {v22 .. v22}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v22

    invoke-virtual {v6}, Lcom/google/payment/SkuDetails;->getSku()Ljava/lang/String;

    move-result-object v23

    invoke-virtual/range {v22 .. v23}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v22

    if-eqz v22, :cond_9

    .line 917
    const-string v22, "queryInventoryAsync"

    new-instance v23, Ljava/lang/StringBuilder;

    invoke-direct/range {v23 .. v23}, Ljava/lang/StringBuilder;-><init>()V

    const-string v24, "SkuDetails ID\uff1a "

    invoke-virtual/range {v23 .. v24}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v23

    invoke-virtual {v6}, Lcom/google/payment/SkuDetails;->getSku()Ljava/lang/String;

    move-result-object v24

    invoke-virtual/range {v23 .. v24}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v23

    invoke-virtual/range {v23 .. v23}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v23

    invoke-static/range {v22 .. v23}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 918
    const-string v22, "queryInventoryAsync"

    new-instance v23, Ljava/lang/StringBuilder;

    invoke-direct/range {v23 .. v23}, Ljava/lang/StringBuilder;-><init>()V

    const-string v24, "SkuDetails Price\uff1a "

    invoke-virtual/range {v23 .. v24}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v23

    invoke-virtual {v6}, Lcom/google/payment/SkuDetails;->getPrice()Ljava/lang/String;

    move-result-object v24

    invoke-virtual/range {v23 .. v24}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v23

    invoke-virtual/range {v23 .. v23}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v23

    invoke-static/range {v22 .. v23}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 919
    invoke-virtual {v9}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v22

    invoke-virtual {v6}, Lcom/google/payment/SkuDetails;->getPrice()Ljava/lang/String;

    move-result-object v23

    invoke-virtual/range {v22 .. v23}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->setGooglePlayCurrencyPrice(Ljava/lang/String;)V

    .line 920
    invoke-virtual {v9}, Lcom/igg/sdk/payment/bean/IGGGameItem;->getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v22

    invoke-virtual {v6}, Lcom/google/payment/SkuDetails;->getmCurrencyCode()Ljava/lang/String;

    move-result-object v23

    invoke-virtual/range {v22 .. v23}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->setGooglePlayPriceCurrencyCode(Ljava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    .line 914
    :cond_9
    add-int/lit8 v8, v8, 0x1

    goto :goto_5

    .line 858
    .end local v6    # "d":Lcom/google/payment/SkuDetails;
    .end local v9    # "item":Lcom/igg/sdk/payment/bean/IGGGameItem;
    .end local v18    # "thisResponse":Ljava/lang/String;
    :cond_a
    add-int/lit8 v15, v15, 0x1

    goto/16 :goto_1

    .line 940
    .end local v10    # "list":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    .end local v11    # "querySkus":Landroid/os/Bundle;
    .end local v13    # "response":I
    .end local v14    # "responseList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    .end local v16    # "skuDetails":Landroid/os/Bundle;
    .end local v17    # "t":I
    .end local v20    # "x":I
    :cond_b
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    move-object/from16 v21, v0

    invoke-virtual/range {v21 .. v21}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 941
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->this$0:Lcom/google/payment/IabHelper;

    move-object/from16 v21, v0

    move-object/from16 v0, v21

    iget-boolean v0, v0, Lcom/google/payment/IabHelper;->mDisposed:Z

    move/from16 v21, v0

    if-nez v21, :cond_5

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$listener:Lcom/google/payment/IabHelper$QueryInventoryListener;

    move-object/from16 v21, v0

    if-eqz v21, :cond_5

    .line 942
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper$4;->val$handler:Landroid/os/Handler;

    move-object/from16 v21, v0

    new-instance v22, Lcom/google/payment/IabHelper$4$4;

    move-object/from16 v0, v22

    move-object/from16 v1, p0

    invoke-direct {v0, v1}, Lcom/google/payment/IabHelper$4$4;-><init>(Lcom/google/payment/IabHelper$4;)V

    invoke-virtual/range {v21 .. v22}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    goto/16 :goto_4
.end method
