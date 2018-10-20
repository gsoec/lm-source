.class public Lcom/igg/sdk/translate/IGGTranslationSet;
.super Ljava/lang/Object;
.source "IGGTranslationSet.java"


# instance fields
.field private language:Ljava/lang/String;

.field private list:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;>;"
        }
    .end annotation
.end field

.field private map:Ljava/util/HashMap;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;>;"
        }
    .end annotation
.end field

.field private sourceLanguage:Ljava/lang/String;

.field private translationSourceList:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/translate/IGGTranslationSource;",
            ">;"
        }
    .end annotation
.end field

.field private type:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;


# direct methods
.method public constructor <init>(Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;Ljava/lang/String;Ljava/util/List;Ljava/lang/String;)V
    .locals 0
    .param p1, "type"    # Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;
    .param p2, "sourceLanguage"    # Ljava/lang/String;
    .param p4, "language"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;",
            "Ljava/lang/String;",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/translate/IGGTranslationSource;",
            ">;",
            "Ljava/lang/String;",
            ")V"
        }
    .end annotation

    .prologue
    .line 21
    .local p3, "translationSourceList":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationSource;>;"
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 22
    iput-object p1, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->type:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    .line 23
    iput-object p2, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->sourceLanguage:Ljava/lang/String;

    .line 24
    iput-object p3, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->translationSourceList:Ljava/util/List;

    .line 25
    iput-object p4, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->language:Ljava/lang/String;

    .line 26
    return-void
.end method


# virtual methods
.method public getByIndex(I)Lcom/igg/sdk/translate/IGGTranslation;
    .locals 6
    .param p1, "index"    # I

    .prologue
    .line 35
    iget-object v4, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->list:Ljava/util/List;

    invoke-interface {v4, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/util/HashMap;

    .line 36
    .local v1, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v4, "t"

    invoke-virtual {v1, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 37
    .local v2, "text":Ljava/lang/String;
    const-string v4, "l"

    invoke-virtual {v1, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 38
    .local v0, "lang":Ljava/lang/String;
    if-eqz v0, :cond_0

    const-string v4, ""

    invoke-virtual {v0, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 39
    iput-object v0, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->sourceLanguage:Ljava/lang/String;

    .line 43
    :cond_0
    new-instance v3, Lcom/igg/sdk/translate/IGGTranslation;

    iget-object v4, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->language:Ljava/lang/String;

    invoke-direct {v3, v2, v4}, Lcom/igg/sdk/translate/IGGTranslation;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 44
    .local v3, "translation":Lcom/igg/sdk/translate/IGGTranslation;
    iget-object v5, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->sourceLanguage:Ljava/lang/String;

    iget-object v4, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->translationSourceList:Ljava/util/List;

    invoke-interface {v4, p1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/igg/sdk/translate/IGGTranslationSource;

    invoke-virtual {v3, v5, v4}, Lcom/igg/sdk/translate/IGGTranslation;->setSourceInfo(Ljava/lang/String;Lcom/igg/sdk/translate/IGGTranslationSource;)V

    .line 45
    return-object v3
.end method

.method public getByName(Ljava/lang/String;)Lcom/igg/sdk/translate/IGGTranslation;
    .locals 7
    .param p1, "name"    # Ljava/lang/String;

    .prologue
    .line 55
    iget-object v6, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->map:Ljava/util/HashMap;

    invoke-virtual {v6, p1}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/util/HashMap;

    .line 56
    .local v2, "tempMap":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v6, "t"

    invoke-virtual {v2, v6}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 57
    .local v3, "text":Ljava/lang/String;
    const-string v6, "l"

    invoke-virtual {v2, v6}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    .line 58
    .local v1, "lang":Ljava/lang/String;
    if-eqz v1, :cond_0

    const-string v6, ""

    invoke-virtual {v1, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-nez v6, :cond_0

    .line 59
    iput-object v1, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->sourceLanguage:Ljava/lang/String;

    .line 62
    :cond_0
    new-instance v4, Lcom/igg/sdk/translate/IGGTranslation;

    iget-object v6, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->language:Ljava/lang/String;

    invoke-direct {v4, v3, v6}, Lcom/igg/sdk/translate/IGGTranslation;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 63
    .local v4, "translation":Lcom/igg/sdk/translate/IGGTranslation;
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    iget-object v6, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->translationSourceList:Ljava/util/List;

    invoke-interface {v6}, Ljava/util/List;->size()I

    move-result v6

    if-ge v0, v6, :cond_2

    .line 64
    iget-object v6, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->translationSourceList:Ljava/util/List;

    invoke-interface {v6, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/igg/sdk/translate/IGGTranslationNamedSource;

    .line 65
    .local v5, "translationNamedSource":Lcom/igg/sdk/translate/IGGTranslationNamedSource;
    invoke-virtual {v5}, Lcom/igg/sdk/translate/IGGTranslationNamedSource;->getName()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v6, p1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v6

    if-eqz v6, :cond_1

    .line 66
    iget-object v6, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->sourceLanguage:Ljava/lang/String;

    invoke-virtual {v4, v6, v5}, Lcom/igg/sdk/translate/IGGTranslation;->setSourceInfo(Ljava/lang/String;Lcom/igg/sdk/translate/IGGTranslationSource;)V

    .line 63
    :cond_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 70
    .end local v5    # "translationNamedSource":Lcom/igg/sdk/translate/IGGTranslationNamedSource;
    :cond_2
    return-object v4
.end method

.method public getType()Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;
    .locals 1

    .prologue
    .line 92
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->type:Lcom/igg/sdk/IGGSDKConstant$IGGTranslationType;

    return-object v0
.end method

.method public setList(Ljava/util/List;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;>;)V"
        }
    .end annotation

    .prologue
    .line 88
    .local p1, "list":Ljava/util/List;, "Ljava/util/List<Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;>;"
    iput-object p1, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->list:Ljava/util/List;

    .line 89
    return-void
.end method

.method public setMap(Ljava/util/HashMap;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;>;)V"
        }
    .end annotation

    .prologue
    .line 79
    .local p1, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;>;"
    iput-object p1, p0, Lcom/igg/sdk/translate/IGGTranslationSet;->map:Ljava/util/HashMap;

    .line 80
    return-void
.end method
