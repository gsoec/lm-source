.class Lcom/igg/iggsdkbusiness/TranslateHelper$5;
.super Ljava/lang/Object;
.source "TranslateHelper.java"

# interfaces
.implements Lcom/igg/sdk/translate/IGGTranslatorListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch_Diplomatic(Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

.field translation:Lcom/igg/sdk/translate/IGGTranslation;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/TranslateHelper;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/TranslateHelper;

    .prologue
    .line 218
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFailed(Ljava/util/List;Lcom/igg/sdk/error/IGGError;)V
    .locals 3
    .param p2, "error"    # Lcom/igg/sdk/error/IGGError;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/translate/IGGTranslationSource;",
            ">;",
            "Lcom/igg/sdk/error/IGGError;",
            ")V"
        }
    .end annotation

    .prologue
    .line 245
    .local p1, "list":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationSource;>;"
    const-string v0, "Translate"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "onFailed = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p2}, Lcom/igg/sdk/error/IGGError;->getOriginal()Ljava/lang/Exception;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 246
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch_DiplomaticFailedCallBack:Ljava/lang/String;

    invoke-virtual {p2}, Lcom/igg/sdk/error/IGGError;->getOriginal()Ljava/lang/Exception;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/TranslateHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 247
    return-void
.end method

.method public onTranslated(Lcom/igg/sdk/translate/IGGTranslationSet;)V
    .locals 8
    .param p1, "translationSet"    # Lcom/igg/sdk/translate/IGGTranslationSet;

    .prologue
    .line 223
    const-string v0, ""

    .line 224
    .local v0, "CallBackStr":Ljava/lang/String;
    const/16 v1, 0x7f

    .line 225
    .local v1, "c":C
    const/16 v2, 0x1f

    .line 227
    .local v2, "c2":C
    :try_start_0
    invoke-virtual {p1}, Lcom/igg/sdk/translate/IGGTranslationSet;->getType()Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    move-result-object v5

    sget-object v6, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->NORMAL:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    if-ne v5, v6, :cond_1

    .line 228
    const/4 v4, 0x0

    .local v4, "i":I
    :goto_0
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    invoke-static {v5}, Lcom/igg/iggsdkbusiness/TranslateHelper;->access$000(Lcom/igg/iggsdkbusiness/TranslateHelper;)I

    move-result v5

    if-ge v4, v5, :cond_0

    .line 229
    invoke-virtual {p1, v4}, Lcom/igg/sdk/translate/IGGTranslationSet;->getByIndex(I)Lcom/igg/sdk/translate/IGGTranslation;

    move-result-object v5

    iput-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->translation:Lcom/igg/sdk/translate/IGGTranslation;

    .line 230
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->translation:Lcom/igg/sdk/translate/IGGTranslation;

    invoke-virtual {v6}, Lcom/igg/sdk/translate/IGGTranslation;->getSourceLanguage()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-static {v1}, Ljava/lang/Character;->toString(C)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->translation:Lcom/igg/sdk/translate/IGGTranslation;

    .line 231
    invoke-virtual {v6}, Lcom/igg/sdk/translate/IGGTranslation;->getText()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-static {v2}, Ljava/lang/Character;->toString(C)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 228
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    .line 233
    :cond_0
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v6, v6, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch_DiplomaticSuccessfulCallBack:Ljava/lang/String;

    invoke-virtual {v5, v6, v0}, Lcom/igg/iggsdkbusiness/TranslateHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 241
    .end local v4    # "i":I
    :goto_1
    return-void

    .line 236
    :cond_1
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v6, v6, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch_DiplomaticFailedCallBack:Ljava/lang/String;

    const-string v7, "IGGSDKConstant.IGGTranslationType != NORMAL"

    invoke-virtual {v5, v6, v7}, Lcom/igg/iggsdkbusiness/TranslateHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    .line 237
    :catch_0
    move-exception v3

    .line 238
    .local v3, "e":Ljava/lang/Exception;
    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$5;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v6, v6, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch_DiplomaticFailedCallBack:Ljava/lang/String;

    invoke-virtual {v3}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v5, v6, v7}, Lcom/igg/iggsdkbusiness/TranslateHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_1
.end method
