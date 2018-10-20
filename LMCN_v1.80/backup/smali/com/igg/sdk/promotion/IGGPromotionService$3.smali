.class Lcom/igg/sdk/promotion/IGGPromotionService$3;
.super Ljava/lang/Object;
.source "IGGPromotionService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/promotion/IGGPromotionService;->loadShowcase(Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/promotion/IGGPromotionService;

.field final synthetic val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/promotion/IGGPromotionService;Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/promotion/IGGPromotionService;

    .prologue
    .line 131
    iput-object p1, p0, Lcom/igg/sdk/promotion/IGGPromotionService$3;->this$0:Lcom/igg/sdk/promotion/IGGPromotionService;

    iput-object p2, p0, Lcom/igg/sdk/promotion/IGGPromotionService$3;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 11
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    const/4 v10, 0x0

    .line 135
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v7

    if-eqz v7, :cond_0

    .line 136
    iget-object v7, p0, Lcom/igg/sdk/promotion/IGGPromotionService$3;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;

    const-string v8, "B001"

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getOriginal()Ljava/lang/Exception;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v9

    invoke-interface {v7, v10, v8, v9}, Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;->onShowcaseLoaded(Lcom/igg/sdk/promotion/model/IGGShowcase;Ljava/lang/String;Ljava/lang/String;)V

    .line 182
    :goto_0
    return-void

    .line 141
    :cond_0
    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 143
    .local v0, "JSON":Lorg/json/JSONObject;
    const-string v7, "error"

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v2

    .line 144
    .local v2, "errorCode":I
    if-eqz v2, :cond_1

    .line 147
    packed-switch v2, :pswitch_data_0

    .line 153
    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    .line 156
    .local v3, "localCode":Ljava/lang/String;
    :goto_1
    const-string v7, "IGGPromotionService"

    invoke-static {v7, p3}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 157
    iget-object v7, p0, Lcom/igg/sdk/promotion/IGGPromotionService$3;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;

    const/4 v8, 0x0

    const-string v9, "msg"

    invoke-virtual {v0, v9}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v9

    invoke-interface {v7, v8, v3, v9}, Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;->onShowcaseLoaded(Lcom/igg/sdk/promotion/model/IGGShowcase;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 177
    .end local v0    # "JSON":Lorg/json/JSONObject;
    .end local v2    # "errorCode":I
    .end local v3    # "localCode":Ljava/lang/String;
    :catch_0
    move-exception v1

    .line 178
    .local v1, "e":Lorg/json/JSONException;
    invoke-virtual {v1}, Lorg/json/JSONException;->printStackTrace()V

    .line 180
    iget-object v7, p0, Lcom/igg/sdk/promotion/IGGPromotionService$3;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;

    const-string v8, "B000"

    invoke-virtual {v1}, Lorg/json/JSONException;->getMessage()Ljava/lang/String;

    move-result-object v9

    invoke-interface {v7, v10, v8, v9}, Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;->onShowcaseLoaded(Lcom/igg/sdk/promotion/model/IGGShowcase;Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 149
    .end local v1    # "e":Lorg/json/JSONException;
    .restart local v0    # "JSON":Lorg/json/JSONObject;
    .restart local v2    # "errorCode":I
    :pswitch_0
    :try_start_1
    const-string v3, "B101"

    .line 150
    .restart local v3    # "localCode":Ljava/lang/String;
    goto :goto_1

    .line 161
    .end local v3    # "localCode":Ljava/lang/String;
    :cond_1
    const-string v7, "result"

    invoke-virtual {v0, v7}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v4

    .line 163
    .local v4, "result":Lorg/json/JSONObject;
    new-instance v5, Lcom/igg/sdk/promotion/model/IGGPromotionReward;

    invoke-direct {v5}, Lcom/igg/sdk/promotion/model/IGGPromotionReward;-><init>()V

    .line 164
    .local v5, "reward":Lcom/igg/sdk/promotion/model/IGGPromotionReward;
    const-string v7, "points"

    invoke-virtual {v4, v7}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v7

    invoke-virtual {v5, v7}, Lcom/igg/sdk/promotion/model/IGGPromotionReward;->setPointsAwarded(I)V

    .line 165
    const-string v7, "point_name"

    invoke-virtual {v4, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v5, v7}, Lcom/igg/sdk/promotion/model/IGGPromotionReward;->setRewardName(Ljava/lang/String;)V

    .line 167
    new-instance v6, Lcom/igg/sdk/promotion/model/IGGShowcase;

    invoke-direct {v6}, Lcom/igg/sdk/promotion/model/IGGShowcase;-><init>()V

    .line 168
    .local v6, "showcase":Lcom/igg/sdk/promotion/model/IGGShowcase;
    const-string v7, "id"

    invoke-virtual {v4, v7}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v7

    invoke-virtual {v6, v7}, Lcom/igg/sdk/promotion/model/IGGShowcase;->setId(I)V

    .line 169
    const-string v7, "title"

    invoke-virtual {v4, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Lcom/igg/sdk/promotion/model/IGGShowcase;->setTitle(Ljava/lang/String;)V

    .line 170
    const-string v7, "content"

    invoke-virtual {v4, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Lcom/igg/sdk/promotion/model/IGGShowcase;->setContent(Ljava/lang/String;)V

    .line 171
    const-string v7, "img"

    invoke-virtual {v4, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Lcom/igg/sdk/promotion/model/IGGShowcase;->setBannerImageURL(Ljava/lang/String;)V

    .line 172
    invoke-virtual {v6, v5}, Lcom/igg/sdk/promotion/model/IGGShowcase;->setReward(Lcom/igg/sdk/promotion/model/IGGPromotionReward;)V

    .line 173
    const-string v7, "target_app_sign"

    invoke-virtual {v4, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Lcom/igg/sdk/promotion/model/IGGShowcase;->setTargetApp(Ljava/lang/String;)V

    .line 174
    const-string v7, "click_url"

    invoke-virtual {v4, v7}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Lcom/igg/sdk/promotion/model/IGGShowcase;->setTargetURL(Ljava/lang/String;)V

    .line 176
    iget-object v7, p0, Lcom/igg/sdk/promotion/IGGPromotionService$3;->val$listener:Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;

    const-string v8, "0"

    const-string v9, ""

    invoke-interface {v7, v6, v8, v9}, Lcom/igg/sdk/promotion/listener/IGGShowcaseLoadingListener;->onShowcaseLoaded(Lcom/igg/sdk/promotion/model/IGGShowcase;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0

    .line 147
    :pswitch_data_0
    .packed-switch 0x7531
        :pswitch_0
    .end packed-switch
.end method
