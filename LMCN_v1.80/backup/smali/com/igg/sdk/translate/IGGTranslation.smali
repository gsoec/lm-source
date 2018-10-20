.class public Lcom/igg/sdk/translate/IGGTranslation;
.super Ljava/lang/Object;
.source "IGGTranslation.java"


# instance fields
.field private language:Ljava/lang/String;

.field private source:Lcom/igg/sdk/translate/IGGTranslationSource;

.field private sourceLanguage:Ljava/lang/String;

.field private text:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "text"    # Ljava/lang/String;
    .param p2, "language"    # Ljava/lang/String;

    .prologue
    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 14
    iput-object p1, p0, Lcom/igg/sdk/translate/IGGTranslation;->text:Ljava/lang/String;

    .line 15
    iput-object p2, p0, Lcom/igg/sdk/translate/IGGTranslation;->language:Ljava/lang/String;

    .line 16
    return-void
.end method


# virtual methods
.method public getLanguage()Ljava/lang/String;
    .locals 1

    .prologue
    .line 28
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslation;->language:Ljava/lang/String;

    return-object v0
.end method

.method public getSourceLanguage()Ljava/lang/String;
    .locals 1

    .prologue
    .line 32
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslation;->sourceLanguage:Ljava/lang/String;

    return-object v0
.end method

.method public getSourceText()Ljava/lang/String;
    .locals 1

    .prologue
    .line 36
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslation;->source:Lcom/igg/sdk/translate/IGGTranslationSource;

    invoke-virtual {v0}, Lcom/igg/sdk/translate/IGGTranslationSource;->getText()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getText()Ljava/lang/String;
    .locals 1

    .prologue
    .line 24
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslation;->text:Ljava/lang/String;

    return-object v0
.end method

.method public setSourceInfo(Ljava/lang/String;Lcom/igg/sdk/translate/IGGTranslationSource;)V
    .locals 0
    .param p1, "sourceLanguage"    # Ljava/lang/String;
    .param p2, "source"    # Lcom/igg/sdk/translate/IGGTranslationSource;

    .prologue
    .line 19
    iput-object p1, p0, Lcom/igg/sdk/translate/IGGTranslation;->sourceLanguage:Ljava/lang/String;

    .line 20
    iput-object p2, p0, Lcom/igg/sdk/translate/IGGTranslation;->source:Lcom/igg/sdk/translate/IGGTranslationSource;

    .line 21
    return-void
.end method
