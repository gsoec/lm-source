.class public Lcom/igg/util/IGGSecretKeyHelper;
.super Ljava/lang/Object;
.source "IGGSecretKeyHelper.java"


# static fields
.field private static HEX_LIST:Ljava/util/ArrayList; = null
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private static final KEY_PART_1:Ljava/lang/String; = "f7fb9a081d87f2c"

.field private static final KEY_PART_2:Ljava/lang/String; = "eaf0832cfcb65c2ee"

.field private static final KEY_PART_3:Ljava/lang/String; = "f7fb9a081d87f2ceaf"

.field private static final KEY_PART_4:Ljava/lang/String; = "0832cfcb65c2ee"

.field private static final TAG:Ljava/lang/String; = "SecretKeyHelper"


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .prologue
    .line 24
    new-instance v0, Ljava/util/ArrayList;

    const/16 v1, 0x10

    invoke-direct {v0, v1}, Ljava/util/ArrayList;-><init>(I)V

    sput-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    .line 25
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "0"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 26
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "1"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 27
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "2"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 28
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "3"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 29
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "4"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 30
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "5"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 31
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "6"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 32
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "7"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 33
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "8"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 34
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "9"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 35
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "a"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 36
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "b"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 37
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "c"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 38
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "d"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 39
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "e"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 40
    sget-object v0, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    const-string v1, "f"

    invoke-virtual {v0, v1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 41
    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 14
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private bin2hex([B)Ljava/lang/String;
    .locals 5
    .param p1, "bytes"    # [B

    .prologue
    .line 170
    new-instance v1, Ljava/lang/StringBuilder;

    const-string v3, ""

    invoke-direct {v1, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 173
    .local v1, "sb":Ljava/lang/StringBuilder;
    const/4 v0, 0x0

    .local v0, "j":I
    :goto_0
    array-length v3, p1

    if-ge v0, v3, :cond_0

    .line 174
    aget-byte v3, p1, v0

    and-int/lit16 v2, v3, 0xff

    .line 175
    .local v2, "v":I
    sget-object v3, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    ushr-int/lit8 v4, v2, 0x4

    invoke-virtual {v3, v4}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 176
    sget-object v3, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    and-int/lit8 v4, v2, 0xf

    invoke-virtual {v3, v4}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 173
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 179
    .end local v2    # "v":I
    :cond_0
    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    return-object v3
.end method

.method private hex2bin(Ljava/lang/String;)[B
    .locals 7
    .param p1, "input"    # Ljava/lang/String;

    .prologue
    const/16 v6, 0x10

    .line 159
    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v2

    .line 160
    .local v2, "len":I
    div-int/lit8 v3, v2, 0x2

    new-array v0, v3, [B

    .line 162
    .local v0, "data":[B
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_0
    if-ge v1, v2, :cond_0

    .line 163
    div-int/lit8 v3, v1, 0x2

    invoke-virtual {p1, v1}, Ljava/lang/String;->charAt(I)C

    move-result v4

    invoke-static {v4, v6}, Ljava/lang/Character;->digit(CI)I

    move-result v4

    shl-int/lit8 v4, v4, 0x4

    add-int/lit8 v5, v1, 0x1

    invoke-virtual {p1, v5}, Ljava/lang/String;->charAt(I)C

    move-result v5

    invoke-static {v5, v6}, Ljava/lang/Character;->digit(CI)I

    move-result v5

    add-int/2addr v4, v5

    int-to-byte v4, v4

    aput-byte v4, v0, v3

    .line 162
    add-int/lit8 v1, v1, 0x2

    goto :goto_0

    .line 166
    :cond_0
    return-object v0
.end method

.method private paintChars(Ljava/lang/String;I)Ljava/lang/String;
    .locals 8
    .param p1, "key"    # Ljava/lang/String;
    .param p2, "distance"    # I

    .prologue
    .line 100
    invoke-static {p1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v6

    if-eqz v6, :cond_0

    .line 101
    const-string v6, ""

    .line 122
    :goto_0
    return-object v6

    .line 104
    :cond_0
    new-instance v5, Ljava/lang/StringBuilder;

    const-string v6, ""

    invoke-direct {v5, v6}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 105
    .local v5, "ret":Ljava/lang/StringBuilder;
    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v1

    .line 106
    .local v1, "len":I
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_1
    if-ge v0, v1, :cond_3

    .line 107
    sget-object v6, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    add-int/lit8 v7, v0, 0x1

    invoke-virtual {p1, v0, v7}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/util/ArrayList;->indexOf(Ljava/lang/Object;)I

    move-result v3

    .line 108
    .local v3, "position":I
    move v4, v3

    .line 109
    .local v4, "relative":I
    if-ltz p2, :cond_1

    .line 110
    add-int v6, v3, p2

    sget-object v7, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    invoke-virtual {v7}, Ljava/util/ArrayList;->size()I

    move-result v7

    rem-int v4, v6, v7

    .line 119
    :goto_2
    sget-object v6, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    invoke-virtual {v6, v4}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 106
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 112
    :cond_1
    neg-int v6, p2

    sget-object v7, Lcom/igg/util/IGGSecretKeyHelper;->HEX_LIST:Ljava/util/ArrayList;

    invoke-virtual {v7}, Ljava/util/ArrayList;->size()I

    move-result v7

    rem-int v2, v6, v7

    .line 113
    .local v2, "offset":I
    sub-int v6, v3, v2

    if-ltz v6, :cond_2

    .line 114
    sub-int v4, v3, v2

    goto :goto_2

    .line 116
    :cond_2
    rsub-int/lit8 v6, v2, 0x10

    add-int v4, v3, v6

    goto :goto_2

    .line 122
    .end local v2    # "offset":I
    .end local v3    # "position":I
    .end local v4    # "relative":I
    :cond_3
    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    goto :goto_0
.end method

.method private swapChars(Ljava/lang/String;)Ljava/lang/String;
    .locals 5
    .param p1, "key"    # Ljava/lang/String;

    .prologue
    .line 131
    invoke-static {p1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_1

    .line 132
    const-string p1, ""

    .line 155
    .end local p1    # "key":Ljava/lang/String;
    :cond_0
    :goto_0
    return-object p1

    .line 135
    .restart local p1    # "key":Ljava/lang/String;
    :cond_1
    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v2

    .line 136
    .local v2, "len":I
    const/4 v4, 0x1

    if-eq v2, v4, :cond_0

    .line 140
    add-int/lit8 v0, v2, -0x2

    .line 141
    .local v0, "endPosition":I
    rem-int/lit8 v4, v2, 0x2

    if-eqz v4, :cond_2

    .line 142
    add-int/lit8 v0, v0, -0x1

    .line 145
    :cond_2
    new-instance v3, Ljava/lang/StringBuilder;

    const-string v4, ""

    invoke-direct {v3, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 146
    .local v3, "ret":Ljava/lang/StringBuilder;
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    if-gt v1, v0, :cond_3

    .line 147
    add-int/lit8 v4, v1, 0x1

    invoke-virtual {p1, v4}, Ljava/lang/String;->charAt(I)C

    move-result v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 148
    invoke-virtual {p1, v1}, Ljava/lang/String;->charAt(I)C

    move-result v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 146
    add-int/lit8 v1, v1, 0x2

    goto :goto_1

    .line 151
    :cond_3
    rem-int/lit8 v4, v2, 0x2

    if-eqz v4, :cond_4

    .line 152
    add-int/lit8 v4, v2, -0x1

    invoke-virtual {p1, v4}, Ljava/lang/String;->charAt(I)C

    move-result v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 155
    :cond_4
    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    goto :goto_0
.end method

.method private xorxor(Ljava/lang/String;)Ljava/lang/String;
    .locals 8
    .param p1, "data"    # Ljava/lang/String;

    .prologue
    const/16 v7, -0x1c

    .line 77
    invoke-static {p1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 78
    const-string v5, ""

    .line 90
    :goto_0
    return-object v5

    .line 81
    :cond_0
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "f7fb9a081d87f2c"

    invoke-direct {p0, v6, v7}, Lcom/igg/util/IGGSecretKeyHelper;->paintChars(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "eaf0832cfcb65c2ee"

    invoke-direct {p0, v6, v7}, Lcom/igg/util/IGGSecretKeyHelper;->paintChars(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "f7fb9a081d87f2ceaf"

    invoke-direct {p0, v6, v7}, Lcom/igg/util/IGGSecretKeyHelper;->paintChars(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, "0832cfcb65c2ee"

    invoke-direct {p0, v6, v7}, Lcom/igg/util/IGGSecretKeyHelper;->paintChars(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-direct {p0, v5}, Lcom/igg/util/IGGSecretKeyHelper;->hex2bin(Ljava/lang/String;)[B

    move-result-object v2

    .line 82
    .local v2, "keyBin":[B
    invoke-direct {p0, p1}, Lcom/igg/util/IGGSecretKeyHelper;->hex2bin(Ljava/lang/String;)[B

    move-result-object v1

    .line 84
    .local v1, "inputBin":[B
    array-length v5, v1

    new-array v4, v5, [B

    .line 86
    .local v4, "ret":[B
    array-length v3, v1

    .line 87
    .local v3, "len":I
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_1
    if-ge v0, v3, :cond_1

    .line 88
    aget-byte v5, v2, v0

    aget-byte v6, v1, v0

    xor-int/2addr v5, v6

    int-to-byte v5, v5

    aput-byte v5, v4, v0

    .line 87
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 90
    :cond_1
    invoke-direct {p0, v4}, Lcom/igg/util/IGGSecretKeyHelper;->bin2hex([B)Ljava/lang/String;

    move-result-object v5

    goto :goto_0
.end method


# virtual methods
.method public demix(Ljava/lang/String;)Ljava/lang/String;
    .locals 4
    .param p1, "mixKey"    # Ljava/lang/String;

    .prologue
    .line 63
    invoke-direct {p0, p1}, Lcom/igg/util/IGGSecretKeyHelper;->xorxor(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 64
    .local v2, "xorxorResult":Ljava/lang/String;
    const/16 v3, 0x1c

    invoke-direct {p0, v2, v3}, Lcom/igg/util/IGGSecretKeyHelper;->paintChars(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v1

    .line 66
    .local v1, "paintResult":Ljava/lang/String;
    invoke-direct {p0, v1}, Lcom/igg/util/IGGSecretKeyHelper;->swapChars(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 68
    .local v0, "demixResult":Ljava/lang/String;
    return-object v0
.end method

.method public mix(Ljava/lang/String;)Ljava/lang/String;
    .locals 4
    .param p1, "key"    # Ljava/lang/String;

    .prologue
    .line 49
    invoke-direct {p0, p1}, Lcom/igg/util/IGGSecretKeyHelper;->swapChars(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 50
    .local v2, "swapResult":Ljava/lang/String;
    const/16 v3, -0x1c

    invoke-direct {p0, v2, v3}, Lcom/igg/util/IGGSecretKeyHelper;->paintChars(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v1

    .line 52
    .local v1, "paintResult":Ljava/lang/String;
    invoke-direct {p0, v1}, Lcom/igg/util/IGGSecretKeyHelper;->xorxor(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 54
    .local v0, "mixResult":Ljava/lang/String;
    return-object v0
.end method
