.class Lcom/igexin/push/extension/distribution/basic/i/c/aq;
.super Ljava/lang/Object;


# instance fields
.field a:Ljava/lang/StringBuilder;

.field b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

.field c:Lcom/igexin/push/extension/distribution/basic/i/c/aj;

.field d:Lcom/igexin/push/extension/distribution/basic/i/c/ai;

.field private e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

.field private f:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

.field private g:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

.field private h:Lcom/igexin/push/extension/distribution/basic/i/c/af;

.field private i:Z

.field private j:Ljava/lang/StringBuilder;

.field private k:Lcom/igexin/push/extension/distribution/basic/i/c/am;

.field private l:Z


# direct methods
.method constructor <init>(Lcom/igexin/push/extension/distribution/basic/i/c/a;Lcom/igexin/push/extension/distribution/basic/i/c/ac;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ar;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->g:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->i:Z

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->j:Ljava/lang/StringBuilder;

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->l:Z

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    return-void
.end method

.method private b(Ljava/lang/String;)V
    .locals 6

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->a()Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/c/ab;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->a()I

    move-result v2

    const-string v3, "Invalid character reference: %s"

    const/4 v4, 0x1

    new-array v4, v4, [Ljava/lang/Object;

    const/4 v5, 0x0

    aput-object p1, v4, v5

    invoke-direct {v1, v2, v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/c/ab;-><init>(ILjava/lang/String;[Ljava/lang/Object;)V

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->add(Ljava/lang/Object;)Z

    :cond_0
    return-void
.end method

.method private c(Ljava/lang/String;)V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->a()Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/c/ab;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->a()I

    move-result v2

    invoke-direct {v1, v2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/ab;-><init>(ILjava/lang/String;)V

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->add(Ljava/lang/Object;)Z

    :cond_0
    return-void
.end method


# virtual methods
.method a()Lcom/igexin/push/extension/distribution/basic/i/c/af;
    .locals 4

    const/4 v3, 0x0

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->l:Z

    if-nez v0, :cond_0

    const-string v0, "Self closing flag not acknowledged"

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Ljava/lang/String;)V

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->l:Z

    :cond_0
    :goto_0
    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->i:Z

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->g:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0, p0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ar;->a(Lcom/igexin/push/extension/distribution/basic/i/c/aq;Lcom/igexin/push/extension/distribution/basic/i/c/a;)V

    goto :goto_0

    :cond_1
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->j:Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->length()I

    move-result v0

    if-lez v0, :cond_2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->j:Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->j:Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->j:Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->length()I

    move-result v2

    invoke-virtual {v0, v3, v2}, Ljava/lang/StringBuilder;->delete(II)Ljava/lang/StringBuilder;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/ah;

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ah;-><init>(Ljava/lang/String;)V

    :goto_1
    return-object v0

    :cond_2
    iput-boolean v3, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->i:Z

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->h:Lcom/igexin/push/extension/distribution/basic/i/c/af;

    goto :goto_1
.end method

.method a(Z)Lcom/igexin/push/extension/distribution/basic/i/c/an;
    .locals 1

    if-eqz p1, :cond_0

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>()V

    :goto_0
    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    return-object v0

    :cond_0
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>()V

    goto :goto_0
.end method

.method a(Ljava/lang/Character;Z)Ljava/lang/Character;
    .locals 8

    const/4 v2, 0x1

    const/4 v3, -0x1

    const/4 v1, 0x0

    const/4 v4, 0x0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->b()Z

    move-result v0

    if-eqz v0, :cond_0

    move-object v0, v4

    :goto_0
    return-object v0

    :cond_0
    if-eqz p1, :cond_1

    invoke-virtual {p1}, Ljava/lang/Character;->charValue()C

    move-result v0

    iget-object v5, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v5}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->c()C

    move-result v5

    if-ne v0, v5, :cond_1

    move-object v0, v4

    goto :goto_0

    :cond_1
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    const/4 v5, 0x6

    new-array v5, v5, [C

    fill-array-data v5, :array_0

    invoke-virtual {v0, v5}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->b([C)Z

    move-result v0

    if-eqz v0, :cond_2

    move-object v0, v4

    goto :goto_0

    :cond_2
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->g()V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    const-string v5, "#"

    invoke-virtual {v0, v5}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->d(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_a

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    const-string v1, "X"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->e(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->l()Ljava/lang/String;

    move-result-object v0

    :goto_1
    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v2

    if-nez v2, :cond_4

    const-string v0, "numeric reference with no numerals"

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->h()V

    move-object v0, v4

    goto :goto_0

    :cond_3
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->m()Ljava/lang/String;

    move-result-object v0

    goto :goto_1

    :cond_4
    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    const-string v4, ";"

    invoke-virtual {v2, v4}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->d(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_5

    const-string v2, "missing semicolon"

    invoke-direct {p0, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Ljava/lang/String;)V

    :cond_5
    if-eqz v1, :cond_8

    const/16 v1, 0x10

    :goto_2
    :try_start_0
    invoke-static {v0, v1}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;I)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    move-result v0

    :goto_3
    if-eq v0, v3, :cond_7

    const v1, 0xd800

    if-lt v0, v1, :cond_6

    const v1, 0xdfff

    if-le v0, v1, :cond_7

    :cond_6
    const v1, 0x10ffff

    if-le v0, v1, :cond_9

    :cond_7
    const-string v0, "character outside of valid range"

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Ljava/lang/String;)V

    const v0, 0xfffd

    invoke-static {v0}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v0

    goto/16 :goto_0

    :cond_8
    const/16 v1, 0xa

    goto :goto_2

    :catch_0
    move-exception v0

    move v0, v3

    goto :goto_3

    :cond_9
    int-to-char v0, v0

    invoke-static {v0}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v0

    goto/16 :goto_0

    :cond_a
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->k()Ljava/lang/String;

    move-result-object v0

    new-instance v5, Ljava/lang/String;

    invoke-direct {v5, v0}, Ljava/lang/String;-><init>(Ljava/lang/String;)V

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    const/16 v6, 0x3b

    invoke-virtual {v3, v6}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->b(C)Z

    move-result v6

    move-object v3, v0

    move v0, v1

    :goto_4
    invoke-virtual {v3}, Ljava/lang/String;->length()I

    move-result v7

    if-lez v7, :cond_c

    if-nez v0, :cond_c

    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/i/b/j;->a(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_b

    move v0, v2

    goto :goto_4

    :cond_b
    invoke-virtual {v3}, Ljava/lang/String;->length()I

    move-result v7

    add-int/lit8 v7, v7, -0x1

    invoke-virtual {v3, v1, v7}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v3

    iget-object v7, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v7}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->e()V

    goto :goto_4

    :cond_c
    if-nez v0, :cond_e

    if-eqz v6, :cond_d

    const-string v0, "invalid named referenece \'%s\'"

    new-array v2, v2, [Ljava/lang/Object;

    aput-object v5, v2, v1

    invoke-static {v0, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Ljava/lang/String;)V

    :cond_d
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->h()V

    move-object v0, v4

    goto/16 :goto_0

    :cond_e
    if-eqz p2, :cond_10

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->n()Z

    move-result v0

    if-nez v0, :cond_f

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->o()Z

    move-result v0

    if-nez v0, :cond_f

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    const/4 v1, 0x3

    new-array v1, v1, [C

    fill-array-data v1, :array_1

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->b([C)Z

    move-result v0

    if-eqz v0, :cond_10

    :cond_f
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->h()V

    move-object v0, v4

    goto/16 :goto_0

    :cond_10
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    const-string v1, ";"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->d(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_11

    const-string v0, "missing semicolon"

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Ljava/lang/String;)V

    :cond_11
    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/i/b/j;->b(Ljava/lang/String;)Ljava/lang/Character;

    move-result-object v0

    goto/16 :goto_0

    :array_0
    .array-data 2
        0x9s
        0xas
        0xcs
        0x20s
        0x3cs
        0x26s
    .end array-data

    :array_1
    .array-data 2
        0x3ds
        0x2ds
        0x5fs
    .end array-data
.end method

.method a(C)V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->j:Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    return-void
.end method

.method a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)V
    .locals 2

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->i:Z

    const-string v1, "There is an unread token pending!"

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->b(ZLjava/lang/String;)V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->h:Lcom/igexin/push/extension/distribution/basic/i/c/af;

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->i:Z

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/af;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    if-ne v0, v1, :cond_1

    check-cast p1, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->k:Lcom/igexin/push/extension/distribution/basic/i/c/am;

    iget-boolean v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/am;->c:Z

    if-eqz v0, :cond_0

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->l:Z

    :cond_0
    :goto_0
    return-void

    :cond_1
    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/af;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->c:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    if-ne v0, v1, :cond_0

    check-cast p1, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/al;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a()I

    move-result v0

    if-lez v0, :cond_0

    const-string v0, "Attributes incorrectly present on end tag"

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c(Ljava/lang/String;)V

    goto :goto_0
.end method

.method a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->g:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    return-void
.end method

.method a(Ljava/lang/String;)V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->j:Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void
.end method

.method b()V
    .locals 1

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->l:Z

    return-void
.end method

.method b(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->f()V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->g:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    return-void
.end method

.method c()V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/an;->n()V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)V

    return-void
.end method

.method c(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V
    .locals 7

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->a()Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/c/ab;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->a()I

    move-result v2

    const-string v3, "Unexpected character \'%s\' in input state [%s]"

    const/4 v4, 0x2

    new-array v4, v4, [Ljava/lang/Object;

    const/4 v5, 0x0

    iget-object v6, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v6}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->c()C

    move-result v6

    invoke-static {v6}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v6

    aput-object v6, v4, v5

    const/4 v5, 0x1

    aput-object p1, v4, v5

    invoke-direct {v1, v2, v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/c/ab;-><init>(ILjava/lang/String;[Ljava/lang/Object;)V

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->add(Ljava/lang/Object;)Z

    :cond_0
    return-void
.end method

.method d()V
    .locals 1

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ai;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d:Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    return-void
.end method

.method d(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V
    .locals 6

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->a()Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/c/ab;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->e:Lcom/igexin/push/extension/distribution/basic/i/c/a;

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->a()I

    move-result v2

    const-string v3, "Unexpectedly reached end of file (EOF) in input state [%s]"

    const/4 v4, 0x1

    new-array v4, v4, [Ljava/lang/Object;

    const/4 v5, 0x0

    aput-object p1, v4, v5

    invoke-direct {v1, v2, v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/c/ab;-><init>(ILjava/lang/String;[Ljava/lang/Object;)V

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->add(Ljava/lang/Object;)Z

    :cond_0
    return-void
.end method

.method e()V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->d:Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)V

    return-void
.end method

.method f()V
    .locals 1

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aj;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    return-void
.end method

.method g()V
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)V

    return-void
.end method

.method h()V
    .locals 1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a:Ljava/lang/StringBuilder;

    return-void
.end method

.method i()Z
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->k:Lcom/igexin/push/extension/distribution/basic/i/c/am;

    if-nez v0, :cond_0

    const/4 v0, 0x0

    :goto_0
    return v0

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/i/c/an;->b:Ljava/lang/String;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->k:Lcom/igexin/push/extension/distribution/basic/i/c/am;

    iget-object v1, v1, Lcom/igexin/push/extension/distribution/basic/i/c/am;->b:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    goto :goto_0
.end method

.method j()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->k:Lcom/igexin/push/extension/distribution/basic/i/c/am;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/i/c/am;->b:Ljava/lang/String;

    return-object v0
.end method
