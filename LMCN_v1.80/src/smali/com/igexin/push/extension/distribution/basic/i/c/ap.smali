.class public Lcom/igexin/push/extension/distribution/basic/i/c/ap;
.super Ljava/lang/Object;


# instance fields
.field private a:Ljava/lang/String;

.field private b:I


# direct methods
.method public constructor <init>(Ljava/lang/String;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x0

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/Object;)V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    return-void
.end method

.method public static f(Ljava/lang/String;)Ljava/lang/String;
    .locals 7

    const/16 v6, 0x5c

    const/4 v0, 0x0

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p0}, Ljava/lang/String;->toCharArray()[C

    move-result-object v4

    array-length v5, v4

    move v1, v0

    :goto_0
    if-ge v0, v5, :cond_2

    aget-char v2, v4, v0

    if-ne v2, v6, :cond_1

    if-eqz v1, :cond_0

    if-ne v1, v6, :cond_0

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    :cond_0
    :goto_1
    add-int/lit8 v0, v0, 0x1

    move v1, v2

    goto :goto_0

    :cond_1
    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    goto :goto_1

    :cond_2
    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private i()I
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    sub-int/2addr v0, v1

    return v0
.end method


# virtual methods
.method public a(CC)Ljava/lang/String;
    .locals 5

    const/4 v0, 0x0

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    move v1, v0

    :cond_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a()Z

    move-result v3

    if-eqz v3, :cond_1

    :goto_0
    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0

    :cond_1
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->d()C

    move-result v3

    invoke-static {v3}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v3

    if-eqz v0, :cond_2

    const/16 v4, 0x5c

    if-eq v0, v4, :cond_3

    :cond_2
    invoke-static {p1}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/Character;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_5

    add-int/lit8 v1, v1, 0x1

    :cond_3
    :goto_1
    if-lez v1, :cond_4

    if-eqz v0, :cond_4

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    :cond_4
    invoke-virtual {v3}, Ljava/lang/Character;->charValue()C

    move-result v0

    if-gtz v1, :cond_0

    goto :goto_0

    :cond_5
    invoke-static {p2}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/Character;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_3

    add-int/lit8 v1, v1, -0x1

    goto :goto_1
.end method

.method public a()Z
    .locals 1

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->i()I

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public a(Ljava/lang/String;)Z
    .locals 6

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    const/4 v1, 0x1

    iget v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    const/4 v4, 0x0

    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v5

    move-object v3, p1

    invoke-virtual/range {v0 .. v5}, Ljava/lang/String;->regionMatches(ZILjava/lang/String;II)Z

    move-result v0

    return v0
.end method

.method public varargs a([C)Z
    .locals 6

    const/4 v0, 0x0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a()Z

    move-result v1

    if-eqz v1, :cond_1

    :cond_0
    :goto_0
    return v0

    :cond_1
    array-length v2, p1

    move v1, v0

    :goto_1
    if-ge v1, v2, :cond_0

    aget-char v3, p1, v1

    iget-object v4, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    iget v5, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {v4, v5}, Ljava/lang/String;->charAt(I)C

    move-result v4

    if-ne v4, v3, :cond_2

    const/4 v0, 0x1

    goto :goto_0

    :cond_2
    add-int/lit8 v1, v1, 0x1

    goto :goto_1
.end method

.method public varargs a([Ljava/lang/String;)Z
    .locals 4

    const/4 v0, 0x0

    array-length v2, p1

    move v1, v0

    :goto_0
    if-ge v1, v2, :cond_0

    aget-object v3, p1, v1

    invoke-virtual {p0, v3}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_1

    const/4 v0, 0x1

    :cond_0
    return v0

    :cond_1
    add-int/lit8 v1, v1, 0x1

    goto :goto_0
.end method

.method public varargs b([Ljava/lang/String;)Ljava/lang/String;
    .locals 3

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    :goto_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a()Z

    move-result v1

    if-nez v1, :cond_0

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a([Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_0

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    add-int/lit8 v1, v1, 0x1

    iput v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    goto :goto_0

    :cond_0
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    iget v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {v1, v0, v2}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public b()Z
    .locals 2

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a()Z

    move-result v0

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {v0, v1}, Ljava/lang/String;->charAt(I)C

    move-result v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->b(I)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public b(Ljava/lang/String;)Z
    .locals 2

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v1

    add-int/2addr v0, v1

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public c(Ljava/lang/String;)V
    .locals 2

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_0

    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "Queue did not match expected sequence"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_0
    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->i()I

    move-result v1

    if-le v0, v1, :cond_1

    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "Queue not long enough to consume sequence"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_1
    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    add-int/2addr v0, v1

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    return-void
.end method

.method public c()Z
    .locals 2

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a()Z

    move-result v0

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {v0, v1}, Ljava/lang/String;->charAt(I)C

    move-result v0

    invoke-static {v0}, Ljava/lang/Character;->isLetterOrDigit(C)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public d()C
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    add-int/lit8 v2, v1, 0x1

    iput v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {v0, v1}, Ljava/lang/String;->charAt(I)C

    move-result v0

    return v0
.end method

.method public d(Ljava/lang/String;)Ljava/lang/String;
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {v0, p1, v1}, Ljava/lang/String;->indexOf(Ljava/lang/String;I)I

    move-result v0

    const/4 v1, -0x1

    if-eq v0, v1, :cond_0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    iget v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {v1, v2, v0}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v0

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v2

    add-int/2addr v1, v2

    iput v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    :goto_0
    return-object v0

    :cond_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->h()Ljava/lang/String;

    move-result-object v0

    goto :goto_0
.end method

.method public e(Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->d(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    return-object v0
.end method

.method public e()Z
    .locals 2

    const/4 v0, 0x0

    :goto_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b()Z

    move-result v1

    if-eqz v1, :cond_0

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    add-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    const/4 v0, 0x1

    goto :goto_0

    :cond_0
    return v0
.end method

.method public f()Ljava/lang/String;
    .locals 3

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    :goto_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a()Z

    move-result v1

    if-nez v1, :cond_1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->c()Z

    move-result v1

    if-nez v1, :cond_0

    const/4 v1, 0x3

    new-array v1, v1, [C

    fill-array-data v1, :array_0

    invoke-virtual {p0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a([C)Z

    move-result v1

    if-eqz v1, :cond_1

    :cond_0
    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    add-int/lit8 v1, v1, 0x1

    iput v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    goto :goto_0

    :cond_1
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    iget v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {v1, v0, v2}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v0

    return-object v0

    :array_0
    .array-data 2
        0x7cs
        0x5fs
        0x2ds
    .end array-data
.end method

.method public g()Ljava/lang/String;
    .locals 3

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    :goto_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a()Z

    move-result v1

    if-nez v1, :cond_1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->c()Z

    move-result v1

    if-nez v1, :cond_0

    const/4 v1, 0x2

    new-array v1, v1, [C

    fill-array-data v1, :array_0

    invoke-virtual {p0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a([C)Z

    move-result v1

    if-eqz v1, :cond_1

    :cond_0
    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    add-int/lit8 v1, v1, 0x1

    iput v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    goto :goto_0

    :cond_1
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    iget v2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {v1, v0, v2}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v0

    return-object v0

    :array_0
    .array-data 2
        0x2ds
        0x5fs
    .end array-data
.end method

.method public h()Ljava/lang/String;
    .locals 2

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    :goto_0
    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a()Z

    move-result v1

    if-nez v1, :cond_0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->d()C

    move-result v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    goto :goto_0

    :cond_0
    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a:Ljava/lang/String;

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b:I

    invoke-virtual {v0, v1}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
