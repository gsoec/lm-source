.class Lcom/igg/iggsdkbusiness/TranslateHelper$3;
.super Ljava/lang/Object;
.source "TranslateHelper.java"

# interfaces
.implements Lcom/igg/sdk/translate/IGGTranslatorListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_Mail(Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/TranslateHelper;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/TranslateHelper;

    .prologue
    .line 146
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$3;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

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
    .line 166
    .local p1, "list":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationSource;>;"
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$3;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$3;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_MailFailedCallBack:Ljava/lang/String;

    invoke-virtual {p2}, Lcom/igg/sdk/error/IGGError;->getOriginal()Ljava/lang/Exception;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/TranslateHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 167
    return-void
.end method

.method public onTranslated(Lcom/igg/sdk/translate/IGGTranslationSet;)V
    .locals 7
    .param p1, "translationSet"    # Lcom/igg/sdk/translate/IGGTranslationSet;

    .prologue
    .line 149
    const/16 v1, 0x7f

    .line 152
    .local v1, "c":C
    :try_start_0
    invoke-virtual {p1}, Lcom/igg/sdk/translate/IGGTranslationSet;->getType()Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    move-result-object v4

    sget-object v5, Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;->NORMAL:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    if-ne v4, v5, :cond_0

    .line 153
    const/4 v4, 0x0

    invoke-virtual {p1, v4}, Lcom/igg/sdk/translate/IGGTranslationSet;->getByIndex(I)Lcom/igg/sdk/translate/IGGTranslation;

    move-result-object v3

    .line 154
    .local v3, "translation":Lcom/igg/sdk/translate/IGGTranslation;
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3}, Lcom/igg/sdk/translate/IGGTranslation;->getSourceLanguage()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-static {v1}, Ljava/lang/Character;->toString(C)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v3}, Lcom/igg/sdk/translate/IGGTranslation;->getText()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 155
    .local v0, "CallBackStr":Ljava/lang/String;
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$3;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$3;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_MailSuccessfulCallBack:Ljava/lang/String;

    invoke-virtual {v4, v5, v0}, Lcom/igg/iggsdkbusiness/TranslateHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 163
    .end local v0    # "CallBackStr":Ljava/lang/String;
    .end local v3    # "translation":Lcom/igg/sdk/translate/IGGTranslation;
    :goto_0
    return-void

    .line 158
    :cond_0
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$3;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$3;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_MailFailedCallBack:Ljava/lang/String;

    const-string v6, "IGGSDKConstant.IGGTranslationType != NORMAL"

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/TranslateHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 159
    :catch_0
    move-exception v2

    .line 160
    .local v2, "e":Ljava/lang/Exception;
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$3;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper$3;->this$0:Lcom/igg/iggsdkbusiness/TranslateHelper;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_MailFailedCallBack:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/TranslateHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
