.class public Lcom/igg/sdk/translate/IGGTranslationSource;
.super Ljava/lang/Object;
.source "IGGTranslationSource.java"


# instance fields
.field private text:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 25
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 26
    return-void
.end method

.method public constructor <init>(Ljava/lang/String;)V
    .locals 0
    .param p1, "text"    # Ljava/lang/String;

    .prologue
    .line 18
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 19
    iput-object p1, p0, Lcom/igg/sdk/translate/IGGTranslationSource;->text:Ljava/lang/String;

    .line 20
    return-void
.end method


# virtual methods
.method public createSources(Ljava/util/List;)Ljava/util/List;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;)",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/translate/IGGTranslationSource;",
            ">;"
        }
    .end annotation

    .prologue
    .line 35
    .local p1, "textList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    .line 36
    .local v2, "translationSourceList":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationSource;>;"
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v4

    if-ge v0, v4, :cond_1

    .line 37
    invoke-interface {p1, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 38
    .local v3, "value":Ljava/lang/String;
    if-eqz v3, :cond_0

    const-string v4, ""

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 39
    new-instance v1, Lcom/igg/sdk/translate/IGGTranslationSource;

    invoke-direct {v1, v3}, Lcom/igg/sdk/translate/IGGTranslationSource;-><init>(Ljava/lang/String;)V

    .line 40
    .local v1, "translationSource":Lcom/igg/sdk/translate/IGGTranslationSource;
    invoke-interface {v2, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 36
    .end local v1    # "translationSource":Lcom/igg/sdk/translate/IGGTranslationSource;
    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 44
    .end local v3    # "value":Ljava/lang/String;
    :cond_1
    return-object v2
.end method

.method public getText()Ljava/lang/String;
    .locals 1

    .prologue
    .line 53
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslationSource;->text:Ljava/lang/String;

    return-object v0
.end method
