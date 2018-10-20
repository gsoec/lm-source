.class public Lcom/igg/sdk/translate/IGGTranslationNamedSource;
.super Lcom/igg/sdk/translate/IGGTranslationSource;
.source "IGGTranslationNamedSource.java"


# instance fields
.field private name:Ljava/lang/String;

.field private text:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 22
    invoke-direct {p0}, Lcom/igg/sdk/translate/IGGTranslationSource;-><init>()V

    .line 24
    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "name"    # Ljava/lang/String;
    .param p2, "text"    # Ljava/lang/String;

    .prologue
    .line 17
    invoke-direct {p0, p2}, Lcom/igg/sdk/translate/IGGTranslationSource;-><init>(Ljava/lang/String;)V

    .line 18
    iput-object p1, p0, Lcom/igg/sdk/translate/IGGTranslationNamedSource;->name:Ljava/lang/String;

    .line 19
    iput-object p2, p0, Lcom/igg/sdk/translate/IGGTranslationNamedSource;->text:Ljava/lang/String;

    .line 20
    return-void
.end method


# virtual methods
.method public createSources(Ljava/util/HashMap;)Ljava/util/List;
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/translate/IGGTranslationNamedSource;",
            ">;"
        }
    .end annotation

    .prologue
    .line 32
    .local p1, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    .line 33
    .local v2, "translationNamedSourceList":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationNamedSource;>;"
    invoke-virtual {p1}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v4

    invoke-interface {v4}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v4

    :cond_0
    :goto_0
    invoke-interface {v4}, Ljava/util/Iterator;->hasNext()Z

    move-result v5

    if-eqz v5, :cond_1

    invoke-interface {v4}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 34
    .local v0, "key":Ljava/lang/String;
    invoke-virtual {p1, v0}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 35
    .local v3, "value":Ljava/lang/String;
    if-eqz v3, :cond_0

    const-string v5, ""

    invoke-virtual {v3, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-nez v5, :cond_0

    .line 36
    new-instance v1, Lcom/igg/sdk/translate/IGGTranslationNamedSource;

    invoke-direct {v1, v0, v3}, Lcom/igg/sdk/translate/IGGTranslationNamedSource;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 37
    .local v1, "translationNamedSource":Lcom/igg/sdk/translate/IGGTranslationNamedSource;
    invoke-interface {v2, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    .line 41
    .end local v0    # "key":Ljava/lang/String;
    .end local v1    # "translationNamedSource":Lcom/igg/sdk/translate/IGGTranslationNamedSource;
    .end local v3    # "value":Ljava/lang/String;
    :cond_1
    return-object v2
.end method

.method public getName()Ljava/lang/String;
    .locals 1

    .prologue
    .line 45
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslationNamedSource;->name:Ljava/lang/String;

    return-object v0
.end method

.method public getText()Ljava/lang/String;
    .locals 1

    .prologue
    .line 50
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslationNamedSource;->text:Ljava/lang/String;

    return-object v0
.end method
