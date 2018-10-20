.class public Lcom/igg/iggsdkbusiness/TranslateHelper;
.super Ljava/lang/Object;
.source "TranslateHelper.java"


# static fields
.field private static instance:Lcom/igg/iggsdkbusiness/TranslateHelper;


# instance fields
.field private IGGIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

.field private TragetLanguage:Ljava/lang/String;

.field TranslateBatchFailedCallBack:Ljava/lang/String;

.field TranslateBatchSuccessfulCallBack:Ljava/lang/String;

.field TranslateBatch_DiplomaticFailedCallBack:Ljava/lang/String;

.field TranslateBatch_DiplomaticSuccessfulCallBack:Ljava/lang/String;

.field TranslateBatch_MailFailedCallBack:Ljava/lang/String;

.field TranslateBatch_MailSuccessfulCallBack:Ljava/lang/String;

.field TranslateFailedCallBack:Ljava/lang/String;

.field TranslateSuccessfulCallBack:Ljava/lang/String;

.field Translate_AAFailedCallBack:Ljava/lang/String;

.field Translate_AASuccessfulCallBack:Ljava/lang/String;

.field Translate_KAFailedCallBack:Ljava/lang/String;

.field Translate_KASuccessfulCallBack:Ljava/lang/String;

.field Translate_MailFailedCallBack:Ljava/lang/String;

.field Translate_MailSuccessfulCallBack:Ljava/lang/String;

.field private batchLen:I

.field private g_id:Ljava/lang/String;

.field m_StrList:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>()V
    .locals 1

    .prologue
    .line 21
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 23
    const-string v0, "TranslateSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateSuccessfulCallBack:Ljava/lang/String;

    .line 24
    const-string v0, "TranslateFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateFailedCallBack:Ljava/lang/String;

    .line 25
    const-string v0, "TranslateBatchSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatchSuccessfulCallBack:Ljava/lang/String;

    .line 26
    const-string v0, "TranslateBatchFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatchFailedCallBack:Ljava/lang/String;

    .line 28
    const-string v0, "TranslateSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_MailSuccessfulCallBack:Ljava/lang/String;

    .line 29
    const-string v0, "Translate_MailFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_MailFailedCallBack:Ljava/lang/String;

    .line 30
    const-string v0, "TranslateBatch_MailSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch_MailSuccessfulCallBack:Ljava/lang/String;

    .line 31
    const-string v0, "TranslateBatch_MailFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch_MailFailedCallBack:Ljava/lang/String;

    .line 33
    const-string v0, "TranslateBatch_DiplomaticSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch_DiplomaticSuccessfulCallBack:Ljava/lang/String;

    .line 34
    const-string v0, "TranslateBatch_DiplomaticFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TranslateBatch_DiplomaticFailedCallBack:Ljava/lang/String;

    .line 36
    const-string v0, "Translate_KASuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_KASuccessfulCallBack:Ljava/lang/String;

    .line 37
    const-string v0, "Translate_KAFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_KAFailedCallBack:Ljava/lang/String;

    .line 39
    const-string v0, "Translate_AASuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_AASuccessfulCallBack:Ljava/lang/String;

    .line 40
    const-string v0, "Translate_AAFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->Translate_AAFailedCallBack:Ljava/lang/String;

    .line 42
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->m_StrList:Ljava/util/List;

    .line 45
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->g_id:Ljava/lang/String;

    .line 48
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->IGGIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 50
    const-string v0, "en"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TragetLanguage:Ljava/lang/String;

    return-void
.end method

.method static synthetic access$000(Lcom/igg/iggsdkbusiness/TranslateHelper;)I
    .locals 1
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/TranslateHelper;

    .prologue
    .line 21
    iget v0, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->batchLen:I

    return v0
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/TranslateHelper;
    .locals 1

    .prologue
    .line 53
    sget-object v0, Lcom/igg/iggsdkbusiness/TranslateHelper;->instance:Lcom/igg/iggsdkbusiness/TranslateHelper;

    if-nez v0, :cond_0

    .line 54
    new-instance v0, Lcom/igg/iggsdkbusiness/TranslateHelper;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/TranslateHelper;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/TranslateHelper;->instance:Lcom/igg/iggsdkbusiness/TranslateHelper;

    .line 56
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/TranslateHelper;->instance:Lcom/igg/iggsdkbusiness/TranslateHelper;

    return-object v0
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 60
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 61
    return-void
.end method

.method public GetStrList(Ljava/lang/String;)Ljava/util/List;
    .locals 7
    .param p1, "str"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            ")",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .prologue
    .line 322
    const/16 v0, 0x1f

    .line 323
    .local v0, "c":C
    new-instance v3, Ljava/util/ArrayList;

    invoke-direct {v3}, Ljava/util/ArrayList;-><init>()V

    .line 324
    .local v3, "strList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    invoke-static {v0}, Ljava/lang/Character;->toString(C)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {p1, v4}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v2

    .line 326
    .local v2, "strArray":[Ljava/lang/String;
    const-string v4, "Translate"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "GetStrList str= "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 327
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_0
    array-length v4, v2

    if-ge v1, v4, :cond_0

    .line 329
    aget-object v4, v2, v1

    invoke-interface {v3, v4}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 330
    const-string v4, "Translate"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "strArray = "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "."

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    aget-object v6, v2, v1

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 327
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 332
    :cond_0
    return-object v3
.end method

.method public SetTragetLanguage(Ljava/lang/String;)V
    .locals 0
    .param p1, "Language"    # Ljava/lang/String;

    .prologue
    .line 64
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TragetLanguage:Ljava/lang/String;

    .line 65
    return-void
.end method

.method public Translate(Ljava/lang/String;)V
    .locals 6
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 68
    new-instance v1, Lcom/igg/sdk/translate/IGGTranslator;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->IGGIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->g_id:Ljava/lang/String;

    const/4 v4, 0x0

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TragetLanguage:Ljava/lang/String;

    invoke-direct {v1, v2, v3, v4, v5}, Lcom/igg/sdk/translate/IGGTranslator;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 71
    .local v1, "translator":Lcom/igg/sdk/translate/IGGTranslator;
    new-instance v0, Lcom/igg/sdk/translate/IGGTranslationSource;

    invoke-direct {v0, p1}, Lcom/igg/sdk/translate/IGGTranslationSource;-><init>(Ljava/lang/String;)V

    .line 72
    .local v0, "translationSource":Lcom/igg/sdk/translate/IGGTranslationSource;
    new-instance v2, Lcom/igg/iggsdkbusiness/TranslateHelper$1;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/TranslateHelper$1;-><init>(Lcom/igg/iggsdkbusiness/TranslateHelper;)V

    invoke-virtual {v1, v0, v2}, Lcom/igg/sdk/translate/IGGTranslator;->translateText(Lcom/igg/sdk/translate/IGGTranslationSource;Lcom/igg/sdk/translate/IGGTranslatorListener;)V

    .line 98
    return-void
.end method

.method public TranslateBatch(Ljava/lang/String;)V
    .locals 8
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 101
    invoke-virtual {p0, p1}, Lcom/igg/iggsdkbusiness/TranslateHelper;->GetStrList(Ljava/lang/String;)Ljava/util/List;

    move-result-object v0

    .line 102
    .local v0, "strList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v4

    iput v4, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->batchLen:I

    .line 104
    new-instance v3, Lcom/igg/sdk/translate/IGGTranslator;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->IGGIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->g_id:Ljava/lang/String;

    const/4 v6, 0x0

    iget-object v7, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TragetLanguage:Ljava/lang/String;

    invoke-direct {v3, v4, v5, v6, v7}, Lcom/igg/sdk/translate/IGGTranslator;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 105
    .local v3, "translator":Lcom/igg/sdk/translate/IGGTranslator;
    new-instance v1, Lcom/igg/sdk/translate/IGGTranslationSource;

    invoke-direct {v1}, Lcom/igg/sdk/translate/IGGTranslationSource;-><init>()V

    .line 106
    .local v1, "translationSource":Lcom/igg/sdk/translate/IGGTranslationSource;
    invoke-virtual {v1, v0}, Lcom/igg/sdk/translate/IGGTranslationSource;->createSources(Ljava/util/List;)Ljava/util/List;

    move-result-object v2

    .line 107
    .local v2, "translationSourceList":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationSource;>;"
    new-instance v4, Lcom/igg/iggsdkbusiness/TranslateHelper$2;

    invoke-direct {v4, p0}, Lcom/igg/iggsdkbusiness/TranslateHelper$2;-><init>(Lcom/igg/iggsdkbusiness/TranslateHelper;)V

    invoke-virtual {v3, v2, v4}, Lcom/igg/sdk/translate/IGGTranslator;->translateTexts(Ljava/util/List;Lcom/igg/sdk/translate/IGGTranslatorListener;)V

    .line 138
    return-void
.end method

.method public TranslateBatch_Diplomatic(Ljava/lang/String;)V
    .locals 8
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 211
    const-string v4, "Translate"

    const-string v5, "TranslateList"

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 212
    invoke-virtual {p0, p1}, Lcom/igg/iggsdkbusiness/TranslateHelper;->GetStrList(Ljava/lang/String;)Ljava/util/List;

    move-result-object v0

    .line 213
    .local v0, "strList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v4

    iput v4, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->batchLen:I

    .line 215
    new-instance v3, Lcom/igg/sdk/translate/IGGTranslator;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->IGGIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->g_id:Ljava/lang/String;

    const/4 v6, 0x0

    iget-object v7, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TragetLanguage:Ljava/lang/String;

    invoke-direct {v3, v4, v5, v6, v7}, Lcom/igg/sdk/translate/IGGTranslator;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 216
    .local v3, "translator":Lcom/igg/sdk/translate/IGGTranslator;
    new-instance v1, Lcom/igg/sdk/translate/IGGTranslationSource;

    invoke-direct {v1}, Lcom/igg/sdk/translate/IGGTranslationSource;-><init>()V

    .line 217
    .local v1, "translationSource":Lcom/igg/sdk/translate/IGGTranslationSource;
    invoke-virtual {v1, v0}, Lcom/igg/sdk/translate/IGGTranslationSource;->createSources(Ljava/util/List;)Ljava/util/List;

    move-result-object v2

    .line 218
    .local v2, "translationSourceList":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationSource;>;"
    new-instance v4, Lcom/igg/iggsdkbusiness/TranslateHelper$5;

    invoke-direct {v4, p0}, Lcom/igg/iggsdkbusiness/TranslateHelper$5;-><init>(Lcom/igg/iggsdkbusiness/TranslateHelper;)V

    invoke-virtual {v3, v2, v4}, Lcom/igg/sdk/translate/IGGTranslator;->translateTexts(Ljava/util/List;Lcom/igg/sdk/translate/IGGTranslatorListener;)V

    .line 249
    return-void
.end method

.method public TranslateBatch_Mail(Ljava/lang/String;)V
    .locals 8
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 172
    const-string v4, "Translate"

    const-string v5, "TranslateList"

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 173
    invoke-virtual {p0, p1}, Lcom/igg/iggsdkbusiness/TranslateHelper;->GetStrList(Ljava/lang/String;)Ljava/util/List;

    move-result-object v0

    .line 174
    .local v0, "strList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v4

    iput v4, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->batchLen:I

    .line 176
    new-instance v3, Lcom/igg/sdk/translate/IGGTranslator;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->IGGIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->g_id:Ljava/lang/String;

    const/4 v6, 0x0

    iget-object v7, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TragetLanguage:Ljava/lang/String;

    invoke-direct {v3, v4, v5, v6, v7}, Lcom/igg/sdk/translate/IGGTranslator;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 177
    .local v3, "translator":Lcom/igg/sdk/translate/IGGTranslator;
    new-instance v1, Lcom/igg/sdk/translate/IGGTranslationSource;

    invoke-direct {v1}, Lcom/igg/sdk/translate/IGGTranslationSource;-><init>()V

    .line 178
    .local v1, "translationSource":Lcom/igg/sdk/translate/IGGTranslationSource;
    invoke-virtual {v1, v0}, Lcom/igg/sdk/translate/IGGTranslationSource;->createSources(Ljava/util/List;)Ljava/util/List;

    move-result-object v2

    .line 179
    .local v2, "translationSourceList":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationSource;>;"
    new-instance v4, Lcom/igg/iggsdkbusiness/TranslateHelper$4;

    invoke-direct {v4, p0}, Lcom/igg/iggsdkbusiness/TranslateHelper$4;-><init>(Lcom/igg/iggsdkbusiness/TranslateHelper;)V

    invoke-virtual {v3, v2, v4}, Lcom/igg/sdk/translate/IGGTranslator;->translateTexts(Ljava/util/List;Lcom/igg/sdk/translate/IGGTranslatorListener;)V

    .line 208
    return-void
.end method

.method public Translate_AA(Ljava/lang/String;)V
    .locals 6
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 286
    const-string v2, "Translate"

    const-string v3, "Translate_AA \u806f\u76df\u516c\u544a"

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 287
    new-instance v1, Lcom/igg/sdk/translate/IGGTranslator;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->IGGIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->g_id:Ljava/lang/String;

    const/4 v4, 0x0

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TragetLanguage:Ljava/lang/String;

    invoke-direct {v1, v2, v3, v4, v5}, Lcom/igg/sdk/translate/IGGTranslator;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 291
    .local v1, "translator":Lcom/igg/sdk/translate/IGGTranslator;
    new-instance v0, Lcom/igg/sdk/translate/IGGTranslationSource;

    invoke-direct {v0, p1}, Lcom/igg/sdk/translate/IGGTranslationSource;-><init>(Ljava/lang/String;)V

    .line 292
    .local v0, "translationSource":Lcom/igg/sdk/translate/IGGTranslationSource;
    new-instance v2, Lcom/igg/iggsdkbusiness/TranslateHelper$7;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/TranslateHelper$7;-><init>(Lcom/igg/iggsdkbusiness/TranslateHelper;)V

    invoke-virtual {v1, v0, v2}, Lcom/igg/sdk/translate/IGGTranslator;->translateText(Lcom/igg/sdk/translate/IGGTranslationSource;Lcom/igg/sdk/translate/IGGTranslatorListener;)V

    .line 318
    return-void
.end method

.method public Translate_KA(Ljava/lang/String;)V
    .locals 6
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 252
    new-instance v1, Lcom/igg/sdk/translate/IGGTranslator;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->IGGIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->g_id:Ljava/lang/String;

    const/4 v4, 0x0

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TragetLanguage:Ljava/lang/String;

    invoke-direct {v1, v2, v3, v4, v5}, Lcom/igg/sdk/translate/IGGTranslator;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 256
    .local v1, "translator":Lcom/igg/sdk/translate/IGGTranslator;
    new-instance v0, Lcom/igg/sdk/translate/IGGTranslationSource;

    invoke-direct {v0, p1}, Lcom/igg/sdk/translate/IGGTranslationSource;-><init>(Ljava/lang/String;)V

    .line 257
    .local v0, "translationSource":Lcom/igg/sdk/translate/IGGTranslationSource;
    new-instance v2, Lcom/igg/iggsdkbusiness/TranslateHelper$6;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/TranslateHelper$6;-><init>(Lcom/igg/iggsdkbusiness/TranslateHelper;)V

    invoke-virtual {v1, v0, v2}, Lcom/igg/sdk/translate/IGGTranslator;->translateText(Lcom/igg/sdk/translate/IGGTranslationSource;Lcom/igg/sdk/translate/IGGTranslatorListener;)V

    .line 283
    return-void
.end method

.method public Translate_Mail(Ljava/lang/String;)V
    .locals 6
    .param p1, "str"    # Ljava/lang/String;

    .prologue
    .line 142
    new-instance v1, Lcom/igg/sdk/translate/IGGTranslator;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->IGGIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->g_id:Ljava/lang/String;

    const/4 v4, 0x0

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/TranslateHelper;->TragetLanguage:Ljava/lang/String;

    invoke-direct {v1, v2, v3, v4, v5}, Lcom/igg/sdk/translate/IGGTranslator;-><init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 145
    .local v1, "translator":Lcom/igg/sdk/translate/IGGTranslator;
    new-instance v0, Lcom/igg/sdk/translate/IGGTranslationSource;

    invoke-direct {v0, p1}, Lcom/igg/sdk/translate/IGGTranslationSource;-><init>(Ljava/lang/String;)V

    .line 146
    .local v0, "translationSource":Lcom/igg/sdk/translate/IGGTranslationSource;
    new-instance v2, Lcom/igg/iggsdkbusiness/TranslateHelper$3;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/TranslateHelper$3;-><init>(Lcom/igg/iggsdkbusiness/TranslateHelper;)V

    invoke-virtual {v1, v0, v2}, Lcom/igg/sdk/translate/IGGTranslator;->translateText(Lcom/igg/sdk/translate/IGGTranslationSource;Lcom/igg/sdk/translate/IGGTranslatorListener;)V

    .line 169
    return-void
.end method
