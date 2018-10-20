.class Lcom/igg/sdk/account/IGGAccountBind$3;
.super Ljava/lang/Object;
.source "IGGAccountBind.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$CGIRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountBind;->bindToExistingAccount(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountBind;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountBind;Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountBind;

    .prologue
    .line 349
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountBind$3;->this$0:Lcom/igg/sdk/account/IGGAccountBind;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountBind$3;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onCGIRequestFinished(Lcom/igg/sdk/error/IGGError;Lorg/json/JSONObject;Ljava/lang/String;)V
    .locals 8
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "responseJSON"    # Lorg/json/JSONObject;
    .param p3, "responseRaw"    # Ljava/lang/String;

    .prologue
    .line 353
    const-string v0, ""

    .line 354
    .local v0, "businessCode":Ljava/lang/String;
    const-string v1, ""

    .line 355
    .local v1, "codeDescription":Ljava/lang/String;
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v6

    if-eqz v6, :cond_0

    .line 356
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v3

    .line 357
    .local v3, "errCode":I
    sparse-switch v3, :sswitch_data_0

    .line 376
    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v0

    .line 379
    :goto_0
    iget-object v6, p0, Lcom/igg/sdk/account/IGGAccountBind$3;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;

    const/4 v7, 0x0

    invoke-interface {v6, v7, v0, v1}, Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    .line 403
    .end local v3    # "errCode":I
    :goto_1
    return-void

    .line 359
    .restart local v3    # "errCode":I
    :sswitch_0
    const-string v0, "B101"

    .line 360
    goto :goto_0

    .line 364
    :sswitch_1
    const-string v0, "B102"

    .line 365
    goto :goto_0

    .line 368
    :sswitch_2
    const-string v0, "B201"

    .line 369
    goto :goto_0

    .line 372
    :sswitch_3
    const-string v0, "B202"

    .line 373
    goto :goto_0

    .line 385
    .end local v3    # "errCode":I
    :cond_0
    :try_start_0
    const-string v6, "return"

    invoke-virtual {p2, v6}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v5

    .line 386
    .local v5, "result":I
    const/4 v6, 0x1

    if-ne v5, v6, :cond_1

    .line 387
    const/4 v4, 0x1

    .line 392
    .local v4, "isSuccess":Z
    :goto_2
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v7

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v6

    const-string v7, ""

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    .line 402
    .end local v5    # "result":I
    :goto_3
    iget-object v6, p0, Lcom/igg/sdk/account/IGGAccountBind$3;->val$listener:Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;

    invoke-interface {v6, v4, v0, v1}, Lcom/igg/sdk/account/IGGAccountBind$IGGBindListener;->onBindFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_1

    .line 389
    .end local v4    # "isSuccess":Z
    .restart local v5    # "result":I
    :cond_1
    const/4 v4, 0x0

    .restart local v4    # "isSuccess":Z
    goto :goto_2

    .line 394
    .end local v4    # "isSuccess":Z
    .end local v5    # "result":I
    :catch_0
    move-exception v2

    .line 395
    .local v2, "e":Lorg/json/JSONException;
    const/4 v4, 0x0

    .line 396
    .restart local v4    # "isSuccess":Z
    const-string v0, "B000"

    .line 397
    const-string v1, "The errCode field is missing within the JSON object"

    .line 398
    invoke-virtual {v2}, Lorg/json/JSONException;->printStackTrace()V

    .line 399
    const-string v6, "IGGAccountBind"

    invoke-static {v6, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_3

    .line 357
    :sswitch_data_0
    .sparse-switch
        0x186bf -> :sswitch_1
        0x186c0 -> :sswitch_1
        0x186ca -> :sswitch_0
        0x186cb -> :sswitch_2
        0x186cd -> :sswitch_3
    .end sparse-switch
.end method
